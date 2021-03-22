using Microsoft.Extensions.DependencyInjection;
using Personas.Infraestructura.Extensiones;
using Personas.negocio.Interfaces;
using Personas.negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.negocio.Extensiones
{
    public static class NegocioConfiguracion
    {
        public static IServiceCollection AddNegocioConfiguration(this IServiceCollection services) 
        {
            services.AddTransient<IPersonaServicio, PersonaServicio>();
            services.AddInfraestructuraConfiguracion();
            return services;
        }
    }
}
