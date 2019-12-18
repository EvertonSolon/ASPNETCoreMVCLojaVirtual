using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        const int _registrosPorPagina = 10;

        public CategoriaRepository(LojaVirtualContext contexto) : base(contexto)
        {

        }

        public void Atualizar(Categoria model)
        {
            _contexto.Update(model);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Categoria model)
        {
            _contexto.Add(model);
            _contexto.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var objeto = Obter(Id);
            _contexto.Remove(objeto);
            _contexto.SaveChanges();
        }

        public Categoria Obter(int Id)
        {
            return _contexto.Categorias.Find(Id);
        }

        public IPagedList<Categoria> ObterTodos(int? pagina)
        {
            return _contexto.Categorias.Include(x => x.CategoriaPai).ToPagedList<Categoria>(pagina ?? 1, _registrosPorPagina);
        }
    }
}
