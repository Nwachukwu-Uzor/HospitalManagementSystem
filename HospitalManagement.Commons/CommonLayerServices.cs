﻿using HospitalManagement.Commons.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Commons
{
    public static class CommonLayerServices
    {
        public static void AddCommonsLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeValidator, DateTimeValidator>();
        }
    }
}