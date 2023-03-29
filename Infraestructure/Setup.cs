using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class Setup
    {
        public static IServiceCollection InitInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}