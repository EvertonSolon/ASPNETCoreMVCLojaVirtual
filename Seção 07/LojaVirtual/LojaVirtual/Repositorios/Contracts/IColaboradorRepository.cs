using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts.Base;

namespace LojaVirtual.Repositorios.Contracts
{
    public interface IColaboradorRepository : IBaseCrudRepository<Colaborador>, IBaseLogin<Colaborador>, IBasePagedList<Colaborador>
    {
    }
}
