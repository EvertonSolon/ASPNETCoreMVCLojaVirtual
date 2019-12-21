using LojaVirtual.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositorios.Contracts
{
    public interface ICategoriaRepository : IBaseCrudRepository<Categoria>
    {
        IPagedList<Categoria> ObterTodos(int? pagina);
    }
}
