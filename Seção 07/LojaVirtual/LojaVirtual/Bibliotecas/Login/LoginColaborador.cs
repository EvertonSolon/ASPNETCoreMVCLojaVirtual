using LojaVirtual.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Login
{
    /// <summary>
    /// Classe responsável pelo gerenciamento do login do Colaborador.
    /// </summary>
    public class LoginColaborador
    {
        private readonly Sessao.Sessao _sessao;
        private readonly string Chave = "Login.Colaborador";

        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador Colaborador)
        {
            var ColaboradorJson = JsonConvert.SerializeObject(Colaborador);
            _sessao.Cadastrar(Chave, ColaboradorJson);
        }

        public Colaborador GetColaborador()
        {
            if (!_sessao.Existe(Chave))
                return null;

            var ColaboradorJson = _sessao.Consultar(Chave);
            var Colaborador = JsonConvert.DeserializeObject<Colaborador>(ColaboradorJson);
            return Colaborador;
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
