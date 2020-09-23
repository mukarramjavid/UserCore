using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BussinessOperation.Implementation;
using BussinessOperation.Interfaces;
using Inferastructure.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interfaces;
using Repository.Providers;
using Services.Implementation;
using Services.Interfaces;

namespace UserLive
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddHttpContextAccessor();
            services.AddRouting();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            this._RegisterRepositories(services);
            this._RegisterServices(services);
            this._RegisterBusinessOperations(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private void _RegisterRepositories(IServiceCollection services)
        {
            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.UserWebApp, this.Configuration.GetConnectionString("ConnectionString") }
            };

            services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);
            services.AddScoped<IDbConnection, MSSQL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        private void _RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
        private void _RegisterBusinessOperations(IServiceCollection services)
        {
            services.AddScoped<IBOUsers, BOUsers>();
        }
    }
}
