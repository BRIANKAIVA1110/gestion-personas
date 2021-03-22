using AutoMapper;
using Personas.negocio.DTOs;
using Personas.Web.Models.ViewModels.Personas;
using Personas.Web.Support.TiposConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Web.Support
{
    /// <summary>
    /// Clase configuracion del automapper
    /// </summary>
    public class AutoMapperConfiguracion : Profile
    {
        public AutoMapperConfiguracion() 
        {
            CreateMap<PersonaVM, PersonaDTO>().ReverseMap();
            //CreateMap<PersonaDTO, PersonaVM>().ConvertUsing<PersonaTypeConverter>();
        }


        
    }
}
