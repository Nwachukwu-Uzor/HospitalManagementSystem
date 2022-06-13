using Hangfire;
using HospitalManagement.BL;
using HospitalManagement.BL.Models;
using HospitalManagement.Data;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HospitalManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalManagement.Api", Version = "v1" });
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            // services.ConfigureIdentity();

            services.AddDataLayerServices();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("SqlServer")));

            services.AddHangfireServer();

            // calling in SendGrid Configurations
            services.Configure<SendGridApi>(Configuration.GetSection("SendGrid"));
            services.Configure<TwilioApi>(Configuration.GetSection("Twilio"));

            // BL services
            services.AddBLayerServices();

            // Data Layer Services
            services.AddDataLayerServices();

            // Service Layer Services
            services.AddServiceLayerServices();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagement.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard();
        }
    }
}
