using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Resources;

namespace Personas.Web.Validator
{
    public class CustomLanguageManager: LanguageManager
    {
        public CustomLanguageManager()
        {
            AddTranslation("es", "NotEmptyValidator", "pepe no vacio");
            AddTranslation("es", "PredicateValidator", "pepe no cumple condicion");
        }
    }
}
