using Application.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Setup
    {
        public static IServiceCollection InitApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient<IWelcomeManager, WelcomeManager>();
            services.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }

    public static class ServiceRegistrationExtensions
    {
        public static void RegisterServicesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetExportedTypes();
            var serviceTypes = types.Where(t => t.IsInterface && t.Name.EndsWith("Service") || t.Name.EndsWith("Manager") && !t.Name.StartsWith("I"));

            foreach (var serviceType in serviceTypes)
            {
                var implementationType = types.FirstOrDefault(t => t.IsClass && serviceType.IsAssignableFrom(t));
                if (implementationType != null)
                {
                    services.AddTransient(serviceType, implementationType);
                }
                else
                {
                    throw new ApplicationException($"No implementation found for service type {serviceType.FullName}");
                }
            }
        }
    }
}
