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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Repository.Implementation;
using Repository.Interfaces;
using Repository.Providers;
using Services.Implementation;
using Services.Interfaces;
using UserLive.Db;
using UserLive.Hubs;
using UserLive.Jobs;

namespace UserLive
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IHubContext<LiveUpdateHub> mMyHubContext;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //services.AddDbContext<ApplicationDbContext>(
            //    options => options.UseSqlServer("data source=192.168.31.51;initial catalog=UserWebApp;user id=sa;password=Sixlogics123;MultipleActiveResultSets=True;"));


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddHttpContextAccessor();
            services.AddRouting();
            services.AddDetection();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //add CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            this._RegisterApplicationServices(services);
            this._RegisterRepositories(services);
            this._RegisterServices(services);
            this._RegisterBusinessOperations(services);

            // SignalR Library
            services.AddSignalR().AddJsonProtocol(options =>
            {
                options.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IBackgroundJobService backgroundJobService = serviceProvider.GetService<IBackgroundJobService>();
            backgroundJobService.ScheduleAutoSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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

            app.UseSignalR(endpoints =>
            {
                endpoints.MapHub<LiveUpdateHub>("/liveupdatehub");
            });

            mMyHubContext = app.ApplicationServices.GetService<IHubContext<LiveUpdateHub>>();

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
            services.AddScoped<ICountryRepository, CountryRepository>();


        }
        private void _RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICountryService, CountryService>();
        }
        private void _RegisterBusinessOperations(IServiceCollection services)
        {
            services.AddScoped<IBOUsers, BOUsers>();
            services.AddScoped<IBOCountry, BOCountry>();
        }
        
        private void _RegisterApplicationServices(IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IBackgroundJobService, BackgroundJobService>();
            services.AddTransient<ScheduledJob>();
        }


    }
}
