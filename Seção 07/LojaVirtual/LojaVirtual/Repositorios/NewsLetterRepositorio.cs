﻿using LojaVirtual.BaseDeDados;
using LojaVirtual.Bibliotecas.PagedLlist;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorios
{
    public class NewsLetterRepositorio : BaseRepositorio, INewsLetterRepository
    {
        public NewsLetterRepositorio(LojaVirtualContext contexto,
            IOptions<PagedListConfiguracao> pagedListConfiguracoes) : base(contexto, pagedListConfiguracoes) { }

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
