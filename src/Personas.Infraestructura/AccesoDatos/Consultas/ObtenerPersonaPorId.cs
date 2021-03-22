using Personas.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace Personas.Infraestructura.AccesoDatos.Consultas
{
    public class ObtenerPersonaPorId : IQuery<Persona>
    {
        private readonly int _id;

        public ObtenerPersonaPorId(int Id)
        {
            this._id = Id;
        }
        public Persona Execute(IDbConnection connection)
        {
            string sql = "select * from personas where id = @Id";

            var result = connection.QueryFirst<Persona>(sql, new { Id = this._id});

            return result;
        }
    }
}
