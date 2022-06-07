using HospitalManagement.BL.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.BL
{
    public static class BLayerServices
    {
        public static void AddBLayerServices(this IServiceCollection services) {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IIdentityNumberGenerator, IdentityNumberGenerator>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IDateTimeValidator, DateTimeValidator>();
        }
    }
}
