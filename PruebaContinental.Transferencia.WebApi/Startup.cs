using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PruebaContinental.Transferencia.Core.Interfaces;
using PruebaContinental.Transferencia.Core.Services;
using PruebaContinental.Transferencia.Infraestructure.Data;
using PruebaContinental.Transferencia.Infraestructure.Filters;
using PruebaContinental.Transferencia.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Transferencia.WebApi
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
            services.AddDbContext<TransferenciaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PruebaContinental")));
            services.AddTransient<ITransferenciasRepository, TransferenciasRepository>();
            services.AddTransient<ITransferenciaServices, TransferenciaServices>();
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFiltersTransferencia>();
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
