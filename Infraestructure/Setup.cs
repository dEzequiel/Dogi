using Application.Interfaces;
using Infraestructure.Authentication;
using Infraestructure.Authentication.Policies;
using Infraestructure.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class Setup
    {
        public static IServiceCollection InitInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IJsonWebTokenProvider, JsonWebTokenProvider>();
            services.AddTransient<JsonWebTokenProvider>();

            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            return services;
        }
    }
}