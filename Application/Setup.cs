using Application.Service.Abstraction;
using Application.Service.Implementation.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Service.Abstraction.Read;
using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

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

            return services;
        }
    }
}
