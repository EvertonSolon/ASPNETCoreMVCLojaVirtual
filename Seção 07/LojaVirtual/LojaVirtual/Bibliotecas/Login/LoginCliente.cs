using LojaVirtual.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LojaVirtual.Bibliotecas.Login
{
    /// <summary>
    /// Classe responsável pelo gerenciamento do login do cliente.
    /// </summary>
    public class LoginCliente
    {
        private readonly Sessao.Sessao _sessao;
        private readonly string Chave = "Login.Cliente";

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            var clienteJson = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(Chave, clienteJson);
        }

        public Cliente GetCliente()
        {
            if (!_sessao.Existe(Chave))
                return null;

            var clienteJson = _sessao.Consultar(Chave);
            var cliente = JsonConvert.DeserializeObject<Cliente>(clienteJson);
            return cliente;
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }




    }
}
