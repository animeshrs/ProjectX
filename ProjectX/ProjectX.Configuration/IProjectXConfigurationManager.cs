namespace ProjectX.Configuration
{
    public interface IProjectXConfigurationManager
    {
        string GetMasterDbConnectionString();
        string GetShardDbConnectionString();
    }
}
