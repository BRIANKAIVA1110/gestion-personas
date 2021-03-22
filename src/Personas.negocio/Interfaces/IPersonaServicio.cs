using Personas.negocio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.negocio.Interfaces
{
    public interface IPersonaServicio
    {
        List<PersonaDTO> ObtenerPersonas();
        PersonaDTO ObtenerPersonaPorId(int id);
    }
}
