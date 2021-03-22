using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Personas.negocio.DTOs;
using Personas.Web.Models.ViewModels.Personas;

namespace Personas.Web.Support.TiposConversion
{
    /// <summary>
    /// Forma "Personalizada" de conversion del objeto Tdestination -> ITypeConverter<Tsouerce, Tdestination>
    /// </summary>
    public class PersonaTypeConverter : ITypeConverter<PersonaDTO, PersonaVM>
    {
        public PersonaVM Convert(PersonaDTO source, PersonaVM destination, ResolutionContext context)
        {
            destination.Nombre = source.Nombre;
            destination.Apellido = source.Apellido;
            destination.Edad = 12345;

            return destination;
        }
    }
}
