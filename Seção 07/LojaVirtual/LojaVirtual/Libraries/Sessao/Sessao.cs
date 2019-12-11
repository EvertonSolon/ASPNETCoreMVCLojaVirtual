using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _contexto;
        public Sessao(IHttpContextAccessor contexto)
        {
            _contexto = contexto;
        }

        public void Cadastrar(string Chave, string Valor)
        {
            _contexto.HttpContext.Session.SetString(Chave, Valor);
        }

        public void Atualizar (string Chave, string Valor)
        {
            if (Existe(Chave))
                Remover(Chave);

            Cadastrar(Chave, Valor);
        }

        public void Remover(string Chave)
        {
            _contexto.HttpContext.Session.Remove(Chave);

        }

        public string Consultar(string Chave)
        {
            return _contexto.HttpContext.Session.GetString(Chave);
        }

        public bool Existe(string Chave)
        {
            return _contexto.HttpContext.Session.GetString(Chave) == null ? false : true;
        }

        public void RemoverTodos()
        {
            _contexto.HttpContext.Session.Clear();
        }
    }
}
