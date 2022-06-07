using HospitalManagement.Data.Repositories;
using HospitalManagement.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Data
{
    public static class DataLayerServices
    {
        public static void AddDataLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDrugRepository, DrugRepository>();
        }
    }
}
