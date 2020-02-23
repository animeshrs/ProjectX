using ProjectX.Configuration;
using StackExchange.Redis;
using System;

namespace ProjectX.Cache
{
    public class RedisConnectionStore
    {
        private readonly IProjectXConfigurationManager _iConfigurationManager;
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public ConnectionMultiplexer Connection => _connection.Value;

        public RedisConnectionStore(IProjectXConfigurationManager iConfigurationManager)
        {
            _iConfigurationManager = iConfigurationManager;
            _connection = new Lazy<ConnectionMultiplexer>(CreateConnection);
        }

        #region private functions

        private ConnectionMultiplexer CreateConnection()
        {
            var connectionString = _iConfigurationManager.GetRedisConnectionString();
            var options = ConfigurationOptions.Parse(connectionString);
            options.AllowAdmin = false;
            options.AbortOnConnectFail = false;
            options.ConnectRetry = 10;
            options.ConnectTimeout = 10;
            options.HighPrioritySocketThreads = true;
            var password = options.Password;
            try
            {
                var result = ConnectionMultiplexer.Connect(options);
                var connectionForLogging = password != null
                    ? result.Configuration.Replace(password, "*****")
                    : result.Configuration;

                result.IncludeDetailInExceptions = true;
                return result;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
