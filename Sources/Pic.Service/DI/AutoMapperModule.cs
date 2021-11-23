using AutoMapper;

namespace Pic.Service.DI
{
    internal static class AutoMapperModule
    {
        internal static void Register()
        {
            var configuration = new MapperConfiguration(conf => conf.AddMaps(new[]
            {
                "Pic.Core.Shared",
                "Pic.Service",
                "Pic.Data",
            }));

            Mapper.Instance = new AutoMapper.Mapper(configuration);
        }
    }
}
