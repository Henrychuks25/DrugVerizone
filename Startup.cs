using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrugVerizone.Classes;
using DrugVerizone.DbContexts;
using DrugVerizone.Entities;
using DrugVerizone.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace DrugVerizone
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
            var connection = Configuration.GetConnectionString("DrugVerify");
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<DrugVerifyContext>(options => options.
            UseLazyLoadingProxies()
            .UseSqlServer(connection));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DrugVerifyContext>()
                .AddDefaultTokenProviders();

            var connectionString = new ConnectionString(Configuration.GetConnectionString("DrugVerify"));
            services.AddSingleton(connectionString);

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    //Fixing JSON Self Referencing Loop Exceptions
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                })
                .AddRazorRuntimeCompilation();
            services.AddScoped<IDrugsRepository, cDrugsRepository>();
            services.AddScoped<IManufacturerRepository, cManufacturerRepository>();
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
