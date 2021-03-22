using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Personas.Web.Models.ViewModels.Personas
{
    public class PersonaVM
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

    }

    public class PersonaVMValidation : AbstractValidator<PersonaVM>
    {
        public PersonaVMValidation() {
            RuleFor(x => x.Nombre).NotEmpty().NotNull().WithMessage("El campo Nombre es debe ser ingresado");
            RuleFor(x => x.Apellido).NotEmpty().NotNull().WithMessage("El campo Apellido es debe ser ingresado");
            RuleFor(x => x.Edad).Must(x => x <= 120).NotEmpty().WithMessage("El dato ingresado no es valido.");
        }
    }

}
