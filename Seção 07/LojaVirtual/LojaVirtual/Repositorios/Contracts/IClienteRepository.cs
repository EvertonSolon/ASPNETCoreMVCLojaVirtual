using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts.Base;

namespace LojaVirtual.Repositorios.Contracts
{
    public interface IClienteRepository : IBaseCrudRepository<Cliente>, IBaseLogin<Cliente>
    {
    }
}
