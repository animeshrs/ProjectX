using Jil;
using ProjectX.Cache;
using ProjectX.Caching.Contracts;
using ProjectX.Enums.Cache;
using StackExchange.Redis;
using System;
using System.Diagnostics;

namespace ProjectX.Caching
{
    public class RedisCacheProvider : IRedisCacheProvider
    {
        //private readonly IApiOutputCache _iOutputCache;
        private readonly IDatabase _iDatabase;

        public RedisCacheProvider(RedisConnectionStore connectionStore)
        {
            //_iOutputCache = iOutputCache;
            _iDatabase = connectionStore.Connection.GetDatabase();
        }

        public T Get<T>(string key)
        {
            try
            {
                var redisValue = _iDatabase.StringGet(key);
                if (!redisValue.HasValue)
                    return default;

                var result = JSON.Deserialize<T>(redisValue.ToString());
                return result;

            }
            catch
            {
                return default;
            }
        }

        public void Set(string key, object data, EnumCaching cacheTimeInMins)
        {
            try
            {
                var serializedObjectToCache = JSON.Serialize(data);
                _iDatabase.StringSet(key, serializedObjectToCache, TimeSpan.FromMinutes((int)cacheTimeInMins));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}