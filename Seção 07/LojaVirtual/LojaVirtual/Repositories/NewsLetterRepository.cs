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
            _contexto.Update(model);
            _contexto.SaveChanges();
        }

        public void Cadastrar(NewsLetterEmail model)
        {
            _contexto.Add(model);
            _contexto.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var objeto = Obter(Id);
            _contexto.Remove(objeto);
            _contexto.SaveChanges();
        }

        public NewsLetterEmail Obter(int Id)
        {
            return _contexto.NewsLetterEmails.Find(Id);
        }

        public IEnumerable<NewsLetterEmail> ObterTodos()
        {
            return _contexto.NewsLetterEmails.ToList();
        }
    }
}
