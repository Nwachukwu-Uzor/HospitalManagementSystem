using HospitalManagement.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HospitalManagement.Services
{
    public static class ServiceLayerServices
    {
        public static void AddServiceLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IDoctorsService, DoctorsService>();
            services.AddScoped<IPatientsService, PatientsService>();
            services.AddScoped<IAppointmentsService, AppointmentsService>();
            services.AddScoped<IDrugsService, DrugsService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
