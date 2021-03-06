﻿using System;
using CT.DB;
using CT.DB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static CT.Services.DBService;
using static CT.Services.TestService;

namespace ColorfulTrip
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
            #region DI。
            //以下使用Appsettings.json
            //services.AddDbContext<CTCoreContext>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("DB")));
            services
                .AddScoped<IDBAction, IDBService>()
                .AddScoped<IHashAction, IHashService>()
                .AddDbContext<CTCoreContext>(options =>
                  options.UseSqlServer(new DBConfig().DevelopDBConn));
            #endregion

            //IDBService : IDBAction
            services.AddMvc();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
