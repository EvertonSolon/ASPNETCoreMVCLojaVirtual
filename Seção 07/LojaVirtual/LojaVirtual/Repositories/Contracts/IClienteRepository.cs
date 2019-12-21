using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IClienteRepository : IBaseCrudRepository<Cliente>
    {
        Cliente Login(string Email, string Senha);
    }
}
