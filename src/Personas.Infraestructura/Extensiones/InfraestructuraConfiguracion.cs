using Microsoft.Extensions.DependencyInjection;
using Personas.Infraestructura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Personas.Infraestructura.Extensiones
{
    public static class InfraestructuraConfiguracion
    {
        private const string connectionString = @"Server = DESKTOP-J4947VK\SQLEXPRESS; Database = PruebaRestful; Integrated Security = True; ";//TODO: traer por config
        
        public static IServiceCollection AddInfraestructuraConfiguracion(this IServiceCollection services) 
        {
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddTransient(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));

            return services;
        }
    }
}
