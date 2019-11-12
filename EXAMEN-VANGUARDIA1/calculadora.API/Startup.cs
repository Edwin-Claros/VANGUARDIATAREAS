using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calculadora.API.Data;
using calculadora.API.Data.RepositoryUnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace calculadora.API
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
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           
             services.AddScoped<IDividirRepository, DividirRepository>();
             services.AddScoped<IExponencialRepository, ExponencialRepository>();
             services.AddScoped<IMultiplicarRepository, MultiplicarRepository>();
             services.AddScoped<IRaizRepository, RaizRepository>();
             services.AddScoped<IRestarRepository, RestarRepository>();
             services.AddScoped<ISumarRepository, SumarRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
             services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();





            app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
