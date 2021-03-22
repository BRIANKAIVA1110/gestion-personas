using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.negocio.Proveedores
{
    public interface IClienteProvider
    {
        object ObtenerCLientes();
        object ObtenerDomicilioCliente();
    }
}
