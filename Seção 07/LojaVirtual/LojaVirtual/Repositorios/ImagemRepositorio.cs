using LojaVirtual.BaseDeDados;
using LojaVirtual.Bibliotecas.PagedLlist;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositorios
{
    public class ImagemRepositorio : BaseRepositorio, IImagemRepository
    {
        public ImagemRepositorio(LojaVirtualContext contexto,
            IOptions<PagedListConfiguracao> pagedListConfiguracoes) : base(contexto, pagedListConfiguracoes) { }


        public void Atualizar(Imagem model)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Imagem model)
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

        public void ExcluirImagensDoProduto(int ProdutoId)
        {
            var resultado = _contexto.Imagens.Where(x => x.ProdutoId == ProdutoId).ToList();

            foreach (var item in resultado)
            {
                _contexto.Remove(item);
            }

            _contexto.SaveChanges();
        }

        public Imagem Obter(int Id)
        {
            return _contexto.Imagens.Find(Id);
        }

        public IEnumerable<Imagem> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IPagedList<Imagem> ObterTodos(int? pagina)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Imagem> ObterTodos(int? pagina, string pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}
