using HospitalManagementBL.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementBL
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
