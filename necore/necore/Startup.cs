using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using necore.model;

namespace necore
{
    public class  Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddScoped<IstudentRep,SqlStudent>();
            services.AddAntiforgery(options =>options.HeaderName = "MY-XSRF-TOKEN");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
           // app.UseDefaultFiles();
            app.UseStaticFiles();
           // app.UseMvc();
           app.UseMvc(routes => { routes.MapRoute("default", "{controller}/{action}/{id?}"); });

            app.Use(async (context,next) =>
            {
                logger.LogInformation("middleware 1 incomming");
                await next();
                logger.LogInformation("middleware 1 outgoing");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("middleware 2 incomming");
                await next();
                logger.LogInformation("middleware 2 outgoing");
            });
           // app.UseStaticFiles();

            app.Run(async (context) =>
            {
                //throw new Exception("error");
                //System.Diagnostics.Process.GetCurrentProcess().ProcessName
                await context.Response.WriteAsync(env.EnvironmentName);
            });
        }
    }
}
