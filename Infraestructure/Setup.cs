using Application.Service.Interfaces;
using Infraestructure.Persistence.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class Setup
    {
        public static IServiceCollection InitInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}