using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewsLetterRepository : INewsLetterRepository
    {
        private readonly LojaVirtualContext _contexto;

        public NewsLetterRepository(LojaVirtualContext contexto)
        {
            _contexto = contexto;
        }

        public void Atualizar(NewsLetterEmail model)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(NewsLetterEmail model)
        {
            _contexto.Add(model);
            _contexto.SaveChanges();
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public NewsLetterEmail Obter(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsLetterEmail> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
