using AutoMapper;

namespace ProjectX.Helpers
{
    public static class AutoMapperHelper
    {
        public static IMapper MapEntities<T1, T2>(T1 source, T2 destination)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.CreateMap<T1, T2>(); });
            var mapper = mapperConfiguration.CreateMapper();

            return mapper;
        }
    }
}