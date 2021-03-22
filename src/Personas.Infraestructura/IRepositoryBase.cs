using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Infraestructura
{
    public interface IRepositoryBase<T>
    {
        W ExecuteQuery<W>(IQuery<W> query) where W : class;
    }
}
