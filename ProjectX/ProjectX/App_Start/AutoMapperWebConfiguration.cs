using AutoMapper;

namespace ProjectX
{
    public class AutoMapperWebConfiguration
    {
        [System.Obsolete]
        public static void Configure()
        {
            var assemblyNames = new[]
            {
                "ProjectX"
            };
            
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(assemblyNames);
            });
        }
    }
}