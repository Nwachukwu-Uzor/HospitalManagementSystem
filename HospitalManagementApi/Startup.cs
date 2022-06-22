using Hangfire;
using HospitalManagementBL;
using HospitalManagementBL.Models;
using HospitalManagementData;
using HospitalManagementDomain.Models;
using HospitalManagementServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;
using Hangfire.PostgreSql;
using System;

namespace HospitalManagementApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddSwaggerDoc(services);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            // services.ConfigureIdentity();

            services.AddDataLayerServices();


            if (_env.IsDevelopment())
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
                });

                // services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("SqlServer")));
    
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("Postgres"));
                });
                //services.AddHangfire(x => x.UsePostgreSqlStorage(Configuration.GetConnectionString("Postgres")));
            }

            //services.AddHangfireServer();

            // calling in SendGrid Configurations
            services.Configure<SendGridApi>(Configuration.GetSection("SendGrid"));
            services.Configure<TwilioApi>(Configuration.GetSection("Twilio"));

            // BL services
            services.AddBLayerServices();

            // Data Layer Services
            services.AddDataLayerServices();

            // Service Layer Services
            services.AddServiceLayerServices();
            services.ConfigureJwt(Configuration);
        }

        private void AddSwaggerDoc(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT authorization header using the Bearer scheme
                                    Enter 'Bearer' [space] and the your token in the text input below
                                    Example: 'Bearer 123456677db",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "0auth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelList.Api", Version = "v1", Description = "<strong>An hotel listing site</strong>" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext _context)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagementApi v1"));

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            _context.Database.EnsureCreated();

            // app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
