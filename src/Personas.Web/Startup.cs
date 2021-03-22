using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using System.Reflection;
using Personas.negocio.Extensiones;
using AutoMapper;
using Personas.Web.Support;
using Personas.Web.Validator;

namespace Personas.Web
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
            services.AddControllersWithViews().AddFluentValidation(config=> 
            {
                //obtiene por assembly las clases que heredan de AbstractValidator
                config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                //mensajes personalizadosm 
                config.ValidatorOptions.LanguageManager = new CustomLanguageManager();
            });

            //agregamos servicios de la capa de negocio
            services.AddNegocioConfiguration();

            //agregamos configuracion de automapper para menejo de DTO -> VM  Y VM -> DTO. en la capa de presentacion
            services.AddAutoMapper(typeof(AutoMapperConfiguracion));
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
