using ProjectX.Enums.Cache;

namespace ProjectX.Caching.Contracts
{
    public interface IRedisCacheProvider
    {
        T Get<T>(string key);

        void Set(string key, object data, EnumCaching cacheTimeInMins);
    }
}
