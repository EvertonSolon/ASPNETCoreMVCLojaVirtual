using LojaVirtual.BaseDeDados;
using LojaVirtual.Bibliotecas.PagedLlist;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using X.PagedList;

namespace LojaVirtual.Repositorios
{
    public class CategoriaRepositorio : BaseRepositorio, ICategoriaRepository
    {
        public CategoriaRepositorio(LojaVirtualContext contexto,
            IOptions<PagedListConfiguracao> pagedListConfiguracoes) : base(contexto, pagedListConfiguracoes) { }

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
            return _contexto.Categorias.Include(x => x.CategoriaPai).ToPagedList(pagina ?? 1, _RegistrosPorPagina);
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return _contexto.Categorias;
        }
    }
}
