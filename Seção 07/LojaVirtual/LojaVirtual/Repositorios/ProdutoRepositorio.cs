using LojaVirtual.BaseDeDados;
using LojaVirtual.Bibliotecas.PagedLlist;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio, IProdutoRepository
    {
        public ProdutoRepositorio(LojaVirtualContext contexto,
            IOptions<PagedListConfiguracao> pagedListConfiguracoes) : base(contexto, pagedListConfiguracoes) { }

        public void Atualizar(Produto model)
        {
            _contexto.Update(model);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Produto model)
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

        public Produto Obter(int Id)
        {
            var resultado = _contexto.Produtos.Include(x => x.Imagens).FirstOrDefault(x => x.Id == Id);
            return resultado;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _contexto.Produtos;
        }

        public IPagedList<Produto> ObterTodos(int? pagina)
        {
            return _contexto.Produtos.Include(x => x.Imagens).ToPagedList(pagina ?? 1, _RegistrosPorPagina);
        }

        public IPagedList<Produto> ObterTodos(int? pagina, string pesquisa)
        {
            var bancoProdutos = _contexto.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                bancoProdutos = bancoProdutos.Where(x => x.Nome.Contains(pesquisa.Trim()));
            }

            return bancoProdutos.Include(x => x.Imagens).ToPagedList(pagina ?? 1, _RegistrosPorPagina);
        }
    }
}
