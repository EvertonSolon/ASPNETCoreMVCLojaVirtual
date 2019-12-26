using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.BaseDeDados;
using LojaVirtual.Bibliotecas.PagedLlist;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LojaVirtual.Repositorios
{
    public class ClienteRepositorio : BaseRepositorio, IClienteRepository
    {

        public ClienteRepositorio(LojaVirtualContext contexto,
            IOptions<PagedListConfiguracao> pagedListConfiguracoes) : base(contexto, pagedListConfiguracoes) { }

        public void Atualizar(Cliente cliente)
        {
            _contexto.Update(cliente);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _contexto.Add(cliente);
            _contexto.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var cliente = Obter(Id);
            _contexto.Remove(cliente);
            _contexto.SaveChanges();
        }

        public Cliente Login(string email, string senha)
        {
            var cliente = _contexto.Clientes.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            return cliente;
        }

        public Cliente Obter(int Id)
        {
            return _contexto.Clientes.Find(Id);
        }

        public List<Cliente> ObterPorEmail(string email)
        {
            var resultado = _contexto.Clientes.Where(x => x.Email == email).ToList();
            return resultado;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _contexto.Clientes.ToList();
        }
    }
}
