using Personas.Infraestructura;
using Personas.Infraestructura.AccesoDatos.Consultas;
using Personas.Infraestructura.Entidades;
using Personas.negocio.DTOs;
using Personas.negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Personas.negocio.Servicios
{
    public class PersonaServicio: IPersonaServicio
    {
        private readonly IRepositoryBase<Persona> _repository;

        public PersonaServicio(IRepositoryBase<Persona> repository)
        {
            this._repository = repository;
        }


        public List<PersonaDTO> ObtenerPersonas() {

            var personas = this._repository.ExecuteQuery(new ObtenerPersonas());

            var resultado = personas.Select(x => new PersonaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToList();

            return resultado;
        }

        public PersonaDTO ObtenerPersonaPorId(int id)
        {
            PersonaDTO personaDTO = new PersonaDTO();
            
            var persona = this._repository.ExecuteQuery(new ObtenerPersonaPorId(id));
            
            if (persona != null) 
            {
                personaDTO.Id = persona.Id;
                personaDTO.Nombre = persona.Nombre;
                personaDTO.Apellido = persona.Apellido;
            }

            return personaDTO;
        }
    }
}
