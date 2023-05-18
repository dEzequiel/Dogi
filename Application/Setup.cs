using Application.Managers;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Read;
using Application.Service.Abstraction.Write;
using Application.Service.Implementation.Command;
using Application.Service.Implementation.Read;
using Application.Service.Implementation.Write;
using Domain.Entities;
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

            services.AddTransient<IReceptionDocumentWrite, ReceptionDocumentWrite>();
            services.AddTransient<IReceptionDocumentRead, ReceptionDocumentRead>();
            services.AddTransient<ReceptionDocument>();

            services.AddTransient<IIndividualProceedingWrite, IndividualProceedingWrite>();
            //services.AddTransient<IReceptionDocumentRead, ReceptionDocumentRead>();
            services.AddTransient<IndividualProceeding>();


            services.AddTransient<IAnimalChipWrite, AnimalChipWrite>();
            services.AddTransient<AnimalChip>();

            services.AddTransient<IWelcomeManager, WelcomeManager>();

            services.AddTransient<ICageWrite, CageWrite>();
            services.AddTransient<Cage>();

            return services;
        }
    }
}
