using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface INewsLetterRepository
    {
        void Cadastrar(NewsLetterEmail model);

        void Atualizar(NewsLetterEmail model);

        void Excluir(int Id);

        NewsLetterEmail Obter(int Id);

        IEnumerable<NewsLetterEmail> ObterTodos();
    }
}
