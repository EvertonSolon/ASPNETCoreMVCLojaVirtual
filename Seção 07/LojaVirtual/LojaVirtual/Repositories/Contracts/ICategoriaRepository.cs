using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories.Contracts
{
    public interface ICategoriaRepository
    {
        void Cadastrar(Categoria model);

        void Atualizar(Categoria model);

        void Excluir(int Id);

        Categoria Obter(int Id);

        IEnumerable<Categoria> ObterTodos();

        IPagedList<Categoria> ObterTodos(int? pagina);
    }
}
