using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LojaVirtualContext _contexto;

        public ClienteRepository(LojaVirtualContext contexto)
        {
            _contexto = contexto;
        }

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
            var cliente = ObterCliente(Id);
            _contexto.Remove(cliente);
            _contexto.SaveChanges();
        }

        public Cliente Login(string Email, string Senha)
        {
            var cliente = _contexto.Clientes.First(x => x.Email == Email && x.Senha == x.Senha);
            return cliente;
        }

        public Cliente ObterCliente(int Id)
        {
            return _contexto.Clientes.Find(Id);
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            return _contexto.Clientes.ToList();
        }
    }
}
