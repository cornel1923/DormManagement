using AutoMapper;
using BusinessLogic;
using DormManagement.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DormManagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddMvc()
              .AddJsonOptions(options =>
              {
                  options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                  options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
              })
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DormManagementContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            services.AddTransient<IRoomBusinessLogic, RoomBusinessLogic>();
            services.ConfigureRepository();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DormManagementContext context)
        {
            app.UseStaticFiles();

            context.SeedInitialData();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
