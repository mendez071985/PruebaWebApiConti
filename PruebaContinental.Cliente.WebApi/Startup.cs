using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PruebaContinental.Cliente.Core.Interfaces;
using PruebaContinental.Cliente.Core.Services;
using PruebaContinental.Cliente.Infraestructure.Data;
using PruebaContinental.Cliente.Infraestructure.Filters;
using PruebaContinental.Cliente.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Cliente.WebApi
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

            services.AddDbContext<ClienteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PruebaContinental")));
            services.AddTransient<IClientesRepository, ClientesRepository>();
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilters>();
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
