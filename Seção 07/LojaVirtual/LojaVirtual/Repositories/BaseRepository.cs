using LojaVirtual.Database;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class BaseRepository
    {
        protected readonly LojaVirtualContext _contexto;

        public BaseRepository(LojaVirtualContext contexto)
        {
            _contexto = contexto;
        }
    }
}
