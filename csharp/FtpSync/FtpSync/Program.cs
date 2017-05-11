using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FtpSync
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Define the connection string here so the entire scope of main can access it
            string connectionString = string.Empty;

            DateTime jobStartTime = DateTime.Now;
            DateTime jobEndTime;
            Stopwatch jobTimer = new Stopwatch();
            double jobElapsedTime = 0;
            bool jobSuccess = true;

            jobTimer.Start();

            if (args.Length > 0)
            {
                Arguments arguments = ConfigurationOverride.Parse(args);
            }
            else
            {
                // Get the connection string from app.config
                ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
                if (settings != null && settings.Count == 1)
                    connectionString = settings[0].ConnectionString;
                else
                {
                    string message = string.Empty;

                    if (settings == null)
                        message = "Connection string not defined.";
                    if (settings.Count > 1)
                        message = "Multiple connection strings defined.";

                    EventLog eventLog = new EventLog("Application");
                    eventLog.Source = "UBSYNC";
                    eventLog.WriteEntry(message, EventLogEntryType.Error, 10001);
                }

                // Import the configuration from the app.config file
                SyncConfiguration configuration = ConfigurationManager.GetSection("importFiles") as SyncConfiguration;

                // Set the database reovery model to bulk_logged
                // UBSYNC is refreshed daily and does not use full recovery mode
                // This step is not needed
                //ToggleSimpleRecovery(1, connectionString);

                // Convert the importFiles collection to a generic list so Parallel.ForEach can be easily used
                List<SyncConfigurationElement> elements = new List<SyncConfigurationElement>();
                foreach (SyncConfigurationElement element in configuration.ImportFiles)
                    elements.Add(element);

                // Import each file in a parallel thread
                Parallel.ForEach(elements, (element) =>
                {
                    Sync current = SyncFactory.Create(element, connectionString);
                    if (current.Synchronize() == false)
                        jobSuccess = false;
                });

                // Revert the database reovery model back to full
                // UBSYNC is refreshed daily and does not use full recovery mode
                // This step is not needed
                //ToggleSimpleRecovery(0, connectionString);

                // Kick off a full backup
                // This is handled by a script and is not needed
                // This is also not needed because full reovery isn't being used
                //FullBackup();
            }

            jobEndTime = DateTime.Now;
            jobTimer.Stop();
            jobElapsedTime = Math.Round(jobTimer.Elapsed.TotalSeconds, 3);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("CSP_INSERT_JOB_METRICS", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 3600;

                    SqlParameter paramJobStartTime = command.Parameters.AddWithValue("@JOB_StartTime", jobStartTime);
                    SqlParameter paramJobEndTime = command.Parameters.AddWithValue("@JOB_EndTime", jobEndTime);
                    SqlParameter paramJobnElapsedTime = command.Parameters.AddWithValue("@JOB_ElapsedTime", jobElapsedTime);
                    SqlParameter paramJobSuccess = command.Parameters.AddWithValue("@JOB_Success", jobSuccess);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Complete");
            Console.ReadLine();
        }

        private static void ToggleSimpleRecovery(int toggle, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("CSP_TOGGLE_SIMPLE_RECOVERY", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 3600;

            SqlParameter paramToggle = command.Parameters.AddWithValue("@Toggle", toggle);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private static void FullBackup()
        {
            // Do a full backup
        }
    }
}