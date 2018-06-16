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
                services.AddScoped<IClientData, ClientDataMock>();
                services.AddScoped<IClientAssessmentData, ClientAssessmentDataMock>();
                services.AddScoped<IClinicianData, ClinicianDataMock>();
                services.AddScoped<IGroupData, GroupDataMock>();
                services.AddScoped<IInventoryData, InventoryDataMock>();
                services.AddScoped<IPermissionData, PermissionDataMock>();
                services.AddScoped<IRecentlyAccessedData, RecentlyAccessedDataMock>();
                services.AddScoped<IRecentlyCreatedData, RecentlyCreatedDataMock>();
                services.AddSingleton<IUserService>(new UserServiceMock(users));
            }
            else
            {
                services.AddScoped<IDynamicFormData, DynamicFormData>();
                services.AddScoped<IAssessmentFormData, AssessmentFormData>();
                services.AddScoped<IAssessmentReviewData, AssessmentReviewData>();
                services.AddScoped<IRecentlyAccessedData, RecentlyAccessedData>();
                services.AddScoped<IRecentlyCreatedData, RecentlyCreatedData>();
                services.AddScoped<IInventoryData, InventoryData>();
                services.AddScoped<IClientData, ClientData>();
                services.AddScoped<IClientAssessmentData, ClientAssessmentData>();
                services.AddScoped<IClinicianData, ClinicianData>();
                services.AddScoped<IEmailData, EmailData>();
                services.AddScoped<IGroupData, GroupData>();
                services.AddScoped<IPermissionData, PermissionData>();
                services.AddScoped<IMessageService,MessageService>();
                services.AddScoped<IUserService,UserService>();
                services.AddScoped<IReportData, ReportData>();

                services.AddScoped<IStrategy, ClientAssessmentByEmailAdminStrategy>();

            }
            services.AddAutoMapper(x=> x.AddProfile(new MappingsProfile()));
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.Login>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.AAB>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.APS>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.BRIEF>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.BRIEF2_3111>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.BRIEF2_3112>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CAB>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CAD_2077>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CAPI>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CHAMP>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CPCI>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CSBI>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.CTI>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.ECBI>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.EDDT>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.FAM>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.FAR>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.FRSBE>();
            //services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.KLDA>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.MEMRY>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.PBRS>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.PSS>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.RADS>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.RAIT>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.RCDS2>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.SDS>();
            //services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.SEARSA>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.SIPA>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.SIQ>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.SOPA>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.SPECTRA>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.STAXI2>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.TOGRA>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.TSCC>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.TSI2>();
            services.AddScoped<Models.DynamicFormModels.IDynamicFormModel, Models.DynamicFormModels.WSA>();

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
                options.ReturnUrlParameter = "ReturnUrl";
                options.AccessDeniedPath = "/auth/accessdenied";
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
                //routes.MapRoute(
                //    name: "settings",
                //    template: "{controller=AccountSettings}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
