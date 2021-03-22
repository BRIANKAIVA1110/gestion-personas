using Personas.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace Personas.Infraestructura.AccesoDatos.Consultas
{
    public class ObtenerPersonas : IQuery<IEnumerable<Persona>>
    {
        public IEnumerable<Persona> Execute(IDbConnection connection)
        {
            string sql = "select * from personas";

            var result = connection.Query<Persona>(sql);

            return result;
        }
    }
}
