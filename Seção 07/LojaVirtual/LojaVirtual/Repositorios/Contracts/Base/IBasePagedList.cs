using LojaVirtual.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositorios.Contracts.Base
{
    public interface IBasePagedList<T> where T : class
    {
        IPagedList<T> ObterTodos(int? pagina);
    }
}
