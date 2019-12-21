using LojaVirtual.BaseDeDados;
using LojaVirtual.Repositorios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorios
{
    public class BaseRepositorio
    {
        protected readonly LojaVirtualContext _contexto;

        public BaseRepositorio(LojaVirtualContext contexto)
        {
            _contexto = contexto;
        }
    }
}
