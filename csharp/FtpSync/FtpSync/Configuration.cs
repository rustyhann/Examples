using System.Configuration;
using System.Linq;

namespace FtpSync
{
    public class SyncConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public SyncConfigurationCollection ImportFiles
        {
            get { return (SyncConfigurationCollection)this[""]; }
            set { this[""] = value; }
        }
    }

    public class SyncConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SyncConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SyncConfigurationElement)element).Name;
        }

        public new SyncConfigurationElement this[string elementName]
        {
            get
            {
                return this.OfType<SyncConfigurationElement>().FirstOrDefault(item => item.Name == elementName);
            }
        }
    }

    public class SyncConfigurationElement : ConfigurationElement
    {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("ftpServer", IsRequired = true)]
        public string FtpServer
        {
            get { return (string)base["ftpServer"]; }
            set { base["ftpServer"] = value; }
        }

        [ConfigurationProperty("ftpPort", IsRequired = true)]
        public string FtpPort
        {
            get { return (string)base["ftpPort"]; }
            set { base["ftpPort"] = value; }
        }

        [ConfigurationProperty("ftpUserName", IsRequired = true)]
        public string FtpUserName
        {
            get { return (string)base["ftpUserName"]; }
            set { base["ftpUserName"] = value; }
        }

        [ConfigurationProperty("ftpPassword", IsRequired = true)]
        public string FtpPassword
        {
            get { return (string)base["ftpPassword"]; }
            set { base["ftpPassword"] = value; }
        }

        [ConfigurationProperty("remoteFileName", IsRequired = true)]
        public string RemoteFileName
        {
            get { return (string)base["remoteFileName"]; }
            set { base["remoteFileName"] = value; }
        }

        [ConfigurationProperty("localFileName", IsRequired = true)]
        public string LocalFileName
        {
            get { return (string)base["localFileName"]; }
            set { base["localFileName"] = value; }
        }

        [ConfigurationProperty("tableName", IsRequired = true)]
        public string TableName
        {
            get { return (string)base["tableName"]; }
            set { base["tableName"] = value; }
        }
    }
}