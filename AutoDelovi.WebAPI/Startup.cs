
//using AutoDelovi.WebAPI.Databases;
//using AutoDelovi.WebAPI.Services;
//using AutoDelovi.WebAPI.Services.Marka;
//using AutoDelovi.WebAPI.Services.Model;
//using AutoDelovi.WebAPI.Services.Narudzba;
//using AutoDelovi.WebAPI.Services.NarudzbaProizvod;
//using AutoDelovi.WebAPI.Services.Proizvod;
//using AutoDelovi.WebAPI.Services.VrstaProizvoda;
using AutoDelovi.WebAPI.Databases;
using AutoDelovi.WebAPI.Services;
using AutoDelovi.WebAPI.Services.Marka;
using AutoDelovi.WebAPI.Services.Model;
using AutoDelovi.WebAPI.Services.Narudzba;
using AutoDelovi.WebAPI.Services.NarudzbaProizvod;
using AutoDelovi.WebAPI.Services.Proizvod;
using AutoDelovi.WebAPI.Services.VrstaProizvoda;
using AutoMapper;
using eAutoDelovi.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI
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
            services.AddControllers();
            services.AddDbContext<AutoDeloviiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AutoDelovi")));

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API WSVAP (WebSmartView)", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
            //CORS
            services.AddCors();
            //Mapper
            services.AddScoped<IBaseService<MProizvod, ProizvodSearch, ProizvodUpsertRequest, ProizvodUpsertRequest>, ProizvodService>();
            services.AddScoped<IBaseService<MMarka, MarkaSearch, MarkaUpsertRequest, MarkaUpsertRequest>, MarkaService>();
            services.AddScoped<IBaseService<MModel, ModelSearch, ModelUpsertRequest, ModelUpsertRequest>, ModelService>();
            services.AddScoped<IBaseService<object, NarudzbaSearch, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, NarudzbaService>();
            services.AddScoped<IBaseService<MVrstaProizvoda, VrstaProizvodaSearch, VrstaProizvodaUpsertRequest, VrstaProizvodaUpsertRequest>, VrstaProizvodaService>();
            services.AddScoped<IBaseService<MNarudzbaProizvod, NarudzbaProizvodSearch, NarudzbaProizvodUpsert, NarudzbaProizvodUpsert>, NarudzbaProizvodService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "My API V1"); //originally "./swagger/v1/swagger.json"
            });
            app.UseRouting();
            app.UseCors(options=>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
