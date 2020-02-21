using AutoMapper;

namespace ProjectX
{
    public class AutoMapperWebConfiguration
    {

        public static void Configure()
        {
            var assemblyNames = new[]
            {
                "ProjectX"
            };
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assemblyNames);
            });

            config.CompileMappings();

        }
    }
}