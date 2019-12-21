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

        public IEnumerable<Cliente> ObterTodos()
        {
            return _contexto.Clientes.ToList();
        }
    }
}
