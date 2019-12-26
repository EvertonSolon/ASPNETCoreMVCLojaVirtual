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
    public class ColaboradorRepositorio : BaseRepositorio, IColaboradorRepository
    {
        public ColaboradorRepositorio(LojaVirtualContext contexto,
            IOptions<PagedListConfiguracao> pagedListConfiguracoes) : base(contexto, pagedListConfiguracoes) { }

        public void Atualizar(Colaborador model)
        {
            _contexto.Update(model);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Colaborador model)
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

        public Colaborador Login(string email, string senha)
        {
            var objeto = _contexto.Colaboradores.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            return objeto;
        }

        public Colaborador Obter(int Id)
        {
            var resultado = _contexto.Colaboradores.Find(Id);
            return resultado;
        }

        public List<Colaborador> ObterPorEmail(string email)
        {
            var resultado = _contexto.Colaboradores.Where(x => x.Email == email).AsNoTracking().ToList();
            return resultado;
        }

        public IEnumerable<Colaborador> ObterTodos()
        {
            return _contexto.Colaboradores.Where(x => x.Tipo != "G");
        }

        public IPagedList<Colaborador> ObterTodos(int? pagina)
        {
            return _contexto.Colaboradores.Where(x => x.Tipo != "G").ToPagedList(pagina ?? 1, _RegistrosPorPagina);
        }
    }
}
