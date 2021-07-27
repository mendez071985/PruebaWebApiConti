using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PruebaContinental.Cuenta.Core.Interfaces;
using PruebaContinental.Cuenta.Core.Services;
using PruebaContinental.Cuenta.Infraestructure.Data;
using PruebaContinental.Cuenta.Infraestructure.Filters;
using PruebaContinental.Cuenta.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Cuenta.WebApi
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options => {
                // options.SuppressModelStateInvalidFilter = true;
            });
            services.AddDbContext<CuentaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PruebaContinental")));
            services.AddTransient<ICuentasRespository, CuentasRespository>();
            services.AddTransient<ICuentaServices, CuentaServices>();
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFiltersCuenta>();
            })
             .AddFluentValidation(options =>
             {
                 options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
