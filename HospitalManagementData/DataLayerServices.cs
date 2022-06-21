using HospitalManagementData.Repositories;
using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementData
{
    public static class DataLayerServices
    {
        public static void AddDataLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IStaffRepository<Staff>, StaffRepository>();
            services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
            services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
            services.AddScoped<IDrugOrderRepository, DrugOrderRepository>();
        }
    }
}
