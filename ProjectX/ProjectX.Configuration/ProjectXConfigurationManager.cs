using System.Configuration;

namespace ProjectX.Configuration
{
    public class ProjectXConfigurationManager : IProjectXConfigurationManager
    {
        public string GetMasterDbConnectionString()
        {
            var connectionString = ConfigurationManager.AppSettings["MasterDbTemplate"];
            return connectionString;
        }

        public string GetShardDbConnectionString()
        {
            var connectionString = ConfigurationManager.AppSettings["ShardDbTemplate"];
            return connectionString;
        }
    }
}
