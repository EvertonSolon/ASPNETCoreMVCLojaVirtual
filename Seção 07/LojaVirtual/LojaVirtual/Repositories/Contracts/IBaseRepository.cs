using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        void Cadastrar(T model);

        void Atualizar(T model);

        void Excluir(int Id);

        T Obter(int Id);

        IEnumerable<T> ObterTodos();
    }
}
