using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using MeallyDBapi.Infrastructure;
using MeallyDBapi.Interceptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RecipeDatabaseDomain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeallyAPI
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IMeallyDataRepository, MeallyDataRepository>();

            services.AddDbContext<RecipeContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("RecipeContext")));

            services.AddCors();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterType<MeallyDataRepository>().As<IMeallyDataRepository>()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor))
                .InstancePerDependency();

            builder.RegisterType<RecipeContext>();
           // builder.Register(x => Consol).SingleInstance();
            builder.RegisterType<LogInterceptor>().SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
         
                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}",
                    new { Controller = "Account", action = "Register" });

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
