using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personas.negocio.DTOs;
using Personas.negocio.Interfaces;
using Personas.Web.Models.ViewModels.Personas;
using System.Collections.Generic;
using System.Linq;

namespace Personas.Web.Controllers
{
    public class PersonasController: Controller
    {
        private readonly IPersonaServicio _personaServicio;
        private readonly IMapper _mapper;

        public PersonasController(IPersonaServicio personaServicio, IMapper mapper) 
        {
            this._personaServicio = personaServicio;
            this._mapper = mapper;
        }

        public ActionResult Index() 
        {
            List<PersonaDTO> personas = this._personaServicio.ObtenerPersonas();

            List<PersonaVM> personasVM = personas.Select(x => this._mapper.Map<PersonaDTO,PersonaVM>(x)).ToList();

            return View(personasVM);
        }

        public ActionResult Crear() {
            return View();
        }

        [HttpPost]
        public ActionResult Crear([FromForm] PersonaVM personaVM) 
        {
            if (ModelState.IsValid) 
            {
                //crear
                return Redirect("index");
            }

            return View();
        }



        public ActionResult Detalles([FromRoute] int Id) 
        {
            PersonaDTO persona = this._personaServicio.ObtenerPersonaPorId(Id);

            PersonaVM personasVM =  this._mapper.Map<PersonaDTO, PersonaVM>(persona);

            return View(personasVM);
        }
        public ActionResult Buscar([FromQuery] string p_query) 
        {
            var personas = this._personaServicio.ObtenerPersonas();

            List<PersonaVM> personasVM;

            if (!string.IsNullOrEmpty(p_query))
            {
                personasVM = personas.Select(x => this._mapper.Map<PersonaDTO, PersonaVM>(x))
                    .Where(x => x.Nombre.Contains(p_query) || x.Apellido.Contains(p_query) || x.Edad.ToString().Contains(p_query))
                    .ToList();
                return View("index", personasVM);
            }
            else {
                personasVM = personas.Select(x => this._mapper.Map<PersonaDTO, PersonaVM>(x)).ToList();
                return View("index", personasVM);
            }
        }
    }
}
