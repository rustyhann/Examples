using LumenWorks.Framework.IO.Csv;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using WinSCP;

namespace FtpSync
{
    public abstract class Sync : IDisposable
    {
        // Configuration from appconfig.exe
        public string Name { get { return name; } set { name = value; } }

        private string name;

        public string FtpServer { get { return ftpServer; } set { ftpServer = value; } }

        private string ftpServer;

        public string FtpPort { get { return ftpPort; } set { ftpPort = value; } }

        private string ftpPort;

        public string FtpUsername { get { return ftpUsername; } set { ftpUsername = value; } }

        private string ftpUsername;

        public string FtpPassword { get { return ftpPassword; } set { ftpPassword = value; } }

        private string ftpPassword;

        public string RemoteFileName { get { return remoteFileName; } set { remoteFileName = value; } }

        private string remoteFileName;

        public string LocalFileName { get { return localFileName; } set { localFileName = value; } }

        private string localFileName;

        public string ConnectionString { get { return connectionString; } set { connectionString = value; } }

        private string connectionString;

        public string TableName { get { return tableName; } set { tableName = value; } }

        private string tableName;

        // Data
        public DataTable Data { get { return data; } set { data = value; } }

        private DataTable data;

        // performance metrics
        public DateTime StartTime { get { return startTime; } set { startTime = value; } }

        private DateTime startTime;

        public DateTime EndTime { get { return endTime; } set { endTime = value; } }

        private DateTime endTime;

        public Double ElapsedTime { get { return elapsedTime; } set { elapsedTime = value; } }

        private Double elapsedTime;

        public Double FetchTime { get { return fetchTime; } set { fetchTime = value; } }

        private Double fetchTime;

        public Double LoadTime { get { return loadTime; } set { loadTime = value; } }

        private Double loadTime;

        public Double CleanTime { get { return cleanTime; } set { cleanTime = value; } }

        private Double cleanTime;

        public Double MergeTime { get { return mergeTime; } set { mergeTime = value; } }

        private Double mergeTime;

        public Int64 RowsUpdated { get { return rowsUpdated; } set { rowsUpdated = value; } }

        private Int64 rowsUpdated;

        public bool Success { get { return success; } set { success = value; } }

        private bool success;

        // Internal Members

        internal Stopwatch timer;

        internal Sync(SyncConfigurationElement element, string cs)
        {
            name = element.Name;
            ftpServer = element.FtpServer;
            ftpPort = element.FtpPort;
            ftpUsername = element.FtpUserName;
            ftpPassword = element.FtpPassword;
            remoteFileName = element.RemoteFileName;
            localFileName = element.LocalFileName;
            connectionString = cs;
            tableName = element.TableName;
            data = new DataTable();
            startTime = DateTime.Now;
            elapsedTime = 0;
            fetchTime = 0;
            loadTime = 0;
            cleanTime = 0;
            mergeTime = 0;
            rowsUpdated = 0;
            success = true;
            timer = new Stopwatch();
            timer.Start();
        }

        internal Sync(Arguments arguments)
        {
            name = arguments.Name;
            ftpServer = arguments.FtpServer;
            ftpPort = arguments.FtpPort;
            ftpUsername = arguments.FtpUserName;
            ftpPassword = arguments.FtpPassword;
            remoteFileName = arguments.RemoteFileName;
            localFileName = arguments.LocalFileName;
            connectionString = arguments.DatabaseConnectionString;
            tableName = arguments.TableName;
            data = new DataTable();
            startTime = DateTime.Now;
            rowsUpdated = 0;
            elapsedTime = 0;
            fetchTime = 0;
            loadTime = 0;
            cleanTime = 0;
            mergeTime = 0;
            success = true;
            timer = new Stopwatch();
            timer.Start();
        }

        public bool Synchronize()
        {
            // Metrics are initialized in the constructor

            try
            {
                Fetch();
                Load();
                Clean();
                Merge();
                Metrics(true);
                return true;
            }
            catch (Exception e)
            {
                // Write the exception to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ToString());
                Console.WriteLine("Error:");
                Console.WriteLine();
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                // Write the exception to the event viewer
                EventLog eventLog = new EventLog("Application");
                eventLog.Source = "UBSYNC";
                string error = ToString();
                error += "\n";
                error += e.ToString();
                eventLog.WriteEntry(error, EventLogEntryType.Error, 10001);

                // Write the metrics to the database
                Metrics(false);

                return false;
            }
        }

        public abstract void Initialize();

        public void Fetch()
        {
            TimeSpan fxStart = timer.Elapsed;

            // Setup session options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = ftpServer,
                UserName = ftpUsername,
                Password = ftpPassword,
                SshPrivateKeyPath = "id_rsa.ppk",
                GiveUpSecurityAndAcceptAnySshHostKey = true,
            };

            using (Session session = new Session())
            {
                // Connect
                session.Open(sessionOptions);

                // Download files
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.GetFiles(remoteFileName, localFileName, false, transferOptions);

                // Throw on any error
                transferResult.Check();
            }

            TimeSpan fxEnd = timer.Elapsed;

            fetchTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public void Load()
        {
            TimeSpan fxStart = timer.Elapsed;

            using (CsvReader csvReader = new CsvReader(new StreamReader(localFileName), true))
                data.Load(csvReader);

            TimeSpan fxEnd = timer.Elapsed;

            loadTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public abstract void Clean();

        public void Merge()
        {
            TimeSpan fxStart = timer.Elapsed;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = StoredProcedure(connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 3600;

            SqlParameter parameter = command.Parameters.AddWithValue("@TableParam", data);
            parameter.SqlDbType = SqlDbType.Structured;

            connection.Open();
            rowsUpdated = command.ExecuteNonQuery();
            connection.Close();

            TimeSpan fxEnd = timer.Elapsed;

            mergeTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public abstract SqlCommand StoredProcedure(SqlConnection connection);

        public void Metrics(bool status)
        {
            // Calculate final metrics
            success = status;
            timer.Stop();
            endTime = DateTime.Now;
            elapsedTime = Math.Round(timer.Elapsed.TotalSeconds, 3);

            // This class implements IDisposable so a using statement is not needed
            // for the connection and command

            // Create a connection to the database
            SqlConnection connection = new SqlConnection(connectionString);

            // Create a command to execute the custom stored procedure CSP_INSERT_SYNC_METRICS
            SqlCommand command = new SqlCommand("CSP_INSERT_SYNC_METRICS", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 3600;

            // Add each metric as a parameter for the stored procedure
            SqlParameter paramTable = command.Parameters.AddWithValue("@SYNC_Table", tableName);
            SqlParameter paramStartTime = command.Parameters.AddWithValue("@SYNC_StartTime", startTime);
            SqlParameter paramEndTime = command.Parameters.AddWithValue("@SYNC_EndTime", endTime);
            SqlParameter paramElapsedTime = command.Parameters.AddWithValue("@SYNC_ElapsedTime", elapsedTime);
            SqlParameter paramFetchTime = command.Parameters.AddWithValue("@SYNC_FetchTime", fetchTime);
            SqlParameter paramLoadTime = command.Parameters.AddWithValue("@SYNC_LoadTime", loadTime);
            SqlParameter paramCleanTime = command.Parameters.AddWithValue("@SYNC_CleanTime", cleanTime);
            SqlParameter paramMergeTime = command.Parameters.AddWithValue("@SYNC_MergeTime", mergeTime);
            SqlParameter paramRowsUpdated = command.Parameters.AddWithValue("@SYNC_RowsUpdated", rowsUpdated);
            SqlParameter paramSuccess = command.Parameters.AddWithValue("@SYNC_Success", success);

            // Opn the connection, execute the stored procedure, and close the connection
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            // Write the final metrics to the console
            if (success == true)
                Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string output = string.Empty;
            output += "Name: " + name + "\n";
            output += "FTP Server: " + ftpServer + "\n";
            output += "FTP Port: " + ftpPort + "\n";
            output += "FTP Username: " + ftpUsername + "\n";
            output += "FTP Password: " + ftpPassword + "\n";
            output += "Remote FileName: " + remoteFileName + "\n";
            output += "Local FileName: " + localFileName + "\n";
            output += "Connection String: " + connectionString + "\n";
            output += "UB Table: " + tableName + "\n";
            output += "Start Time: " + startTime + "\n";
            output += "End Time: " + endTime + "\n";
            output += "Elapsed Time: " + elapsedTime + " s\n";
            output += "Fetch Time: " + fetchTime + " ms\n";
            output += "Load Time: " + loadTime + " ms\n";
            output += "Clean Time: " + cleanTime + " ms\n";
            output += "Merge Time: " + MergeTime + " ms\n";
            output += "Total Rows Updated: " + rowsUpdated + "\n";
            output += "Success: " + success + "\n";
            return output;
        }

        // IDisposable Implementation

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Sync()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                data.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }
    }
}