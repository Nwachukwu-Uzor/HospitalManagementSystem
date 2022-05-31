using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public static class ServiceLayerServices
    {
        public static void AddServiceLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityNumberGenerator, IdentityNumberGenerator>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISmsService, SmsService>();
        }
    }
}
