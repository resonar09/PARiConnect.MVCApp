using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PARiConnect.MVCApp.Helpers;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;

namespace PARiConnect.MVCApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            var users = new Dictionary<string,string> {{"dperez@parinc.com","password"}};
            
            //App Services
            if (Environment.IsDevelopment() && appSettings.Offline)
            {
                services.AddScoped<IDynamicFormData, DynamicFormDataMock>();
                services.AddScoped<IAssessmentReviewData, AssessmentReviewDataMock>();
                services.AddScoped<IRecentlyAccessedData, RecentlyAccessedDataMock>();
                services.AddScoped<IInventoryUsesData, InventoryUsesDataMock>();
                services.AddScoped<IClientData, ClientDataMock>();
                services.AddScoped<IClinicianData, ClinicianDataMock>();
                services.AddScoped<IGroupData, GroupDataMock>();
                services.AddSingleton<IUserService>(new UserServiceMock(users));
            }
            else
            {
                services.AddScoped<IDynamicFormData, DynamicFormData>();
                services.AddScoped<IAssessmentReviewData, AssessmentReviewData>();
                services.AddScoped<IRecentlyAccessedData, RecentlyAccessedData>();
                services.AddScoped<IInventoryUsesData, InventoryUsesData>();
                services.AddScoped<IClientData, ClientData>();
                services.AddScoped<IClinicianData, ClinicianData>();
                services.AddScoped<IGroupData, GroupData>();
                services.AddScoped<IPermissionData, PermissionData>();
                services.AddScoped<IUserService,UserService>();
            }
            services.AddAutoMapper(x=> x.AddProfile(new MappingsProfile()));
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.Login>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CAB>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, ClientEdit>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, GroupEdit>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, ClinicianInvite>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options => {
                options.LoginPath = "/auth/login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
