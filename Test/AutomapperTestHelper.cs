using AutoMapper;
using System.Reflection;

namespace Test
{
    internal class AutomapperTestHelper
    {
        internal static IMapper CreateAutoMapperConfiguration()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(new List<Assembly> {
                    Assembly.Load($"{nameof(Application)}"),
                    Assembly.Load($"{nameof(Infraestructure)}"),
                });
            });

            return mappingConfig.CreateMapper();
        }
    }
}
