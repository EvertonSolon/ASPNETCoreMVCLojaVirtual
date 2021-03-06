﻿using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts.Base;

namespace LojaVirtual.Repositorios.Contracts
{
    public interface ICategoriaRepository : IBaseCrudRepository<Categoria>, IBasePagedList<Categoria>
    {
        
    }
}
