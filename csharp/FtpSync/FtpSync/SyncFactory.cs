namespace FtpSync
{
    public static class SyncFactory
    {
        public static Sync Create(SyncConfigurationElement element, string connectionString)
        {
            switch (element.Name)
            {
                case "TRANS_TYPES":
                    return new TRANS_TYPES(element, connectionString);

                case "TRANSACTIONS":
                    return new TRANSACTIONS(element, connectionString);

                case "TRANS_METHOD_DESC":
                    return new TRANS_METHOD_DESC(element, connectionString);

                case "ACCT_ORDER":
                    return new ACCT_ORDER(element, connectionString);

                case "EVT_REGIS":
                    return new EVT_REGIS(element, connectionString);

                case "STATUS_MASTER":
                    return new STATUS_MASTER(element, connectionString);

                case "EVENT_MASTER":
                    return new EVENT_MASTER(element, connectionString);

                case "EVT_CLASS":
                    return new EVT_CLASS(element, connectionString);

                case "ACCT_MASTER":
                    return new ACCT_MASTER(element, connectionString);

                default:
                    throw new System.ArgumentException("Invalid Configuration, importFiles name not found.");
            }
        }
    }
}