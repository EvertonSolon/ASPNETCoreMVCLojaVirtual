using LojaVirtual.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorios.Contracts
{
    public interface INewsLetterRepository : IBaseCrudRepository<NewsLetterEmail>
    {
    }
}
