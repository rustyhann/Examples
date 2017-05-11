using Fclp;

namespace FtpSync
{
    public class Arguments
    {
        public string Name { get; set; }
        public string FtpServer { get; set; }
        public string FtpPort { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string RemoteFileName { get; set; }
        public string LocalFileName { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string TableName { get; set; }
    }

    public static class ConfigurationOverride
    {
        public static Arguments Parse(string[] args)
        {
            var parser = new FluentCommandLineParser<Arguments>();

            parser.Setup(arg => arg.Name)
                .As("Name")
                .Required();
            parser.Setup(arg => arg.FtpServer)
                .As("FtpServer")
                .Required();
            parser.Setup(arg => arg.FtpPort)
                .As("FtpPort")
                .Required();
            parser.Setup(arg => arg.FtpUserName)
                .As("FtpUserName")
                .Required();
            parser.Setup(arg => arg.FtpPassword)
                .As("FtpPassword")
                .Required();
            parser.Setup(arg => arg.RemoteFileName)
                .As("RemoteFileName")
                .Required();
            parser.Setup(arg => arg.LocalFileName)
                .As("LocalFileName")
                .Required();
            parser.Setup(arg => arg.DatabaseConnectionString)
                .As("DatabaseConnectionString")
                .Required();
            parser.Setup(arg => arg.TableName)
                .As("TableName")
                .Required();

            parser.Parse(args);

            return parser.Object;
        }        
    }    
}
