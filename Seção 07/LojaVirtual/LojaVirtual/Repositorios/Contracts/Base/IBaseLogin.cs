using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorios.Contracts.Base
{
    public interface IBaseLogin<T> where T : class
    {
        T Login(string email, string senha);
    }
}
