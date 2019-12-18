using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Libraries.Filtro;
//using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        //private readonly LojaVirtualContext _contexto;
        private readonly IClienteRepository _clienteRepository;
        private readonly INewsLetterRepository _newsLetterRepository;
        private readonly LoginCliente _loginCliente;

        public HomeController(IClienteRepository clienteRepository, 
            INewsLetterRepository newsLetterRepository,
            LoginCliente loginCliente)
        {
            _clienteRepository = clienteRepository;
            _newsLetterRepository = newsLetterRepository;
            _loginCliente = loginCliente;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsLetterEmail newsLetter)
        {

            //Validação do formulário
            if (!ModelState.IsValid)
                return View();

            //Adição no banco de dados
            //_repository.NewsLetterEmails.Add(newsLetter);
            //_repository.SaveChanges();
            _newsLetterRepository.Cadastrar(newsLetter);

            TempData["MSG_SUCESSO"] = "E-mail cadastrado!";
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                var form = HttpContext.Request.Form;

                var contato = new Contato
                {
                    Nome = form["nome"],
                    Email = form["email"],
                    Texto = form["texto"]
                };

                var ListaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                var validacoesOk = Validator.TryValidateObject(contato, contexto, ListaMensagens, true);

                if (!validacoesOk)
                {
                    var sb = new StringBuilder();

                    foreach (var texto in ListaMensagens)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }

                    ViewData["MSG_ERRO"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }
                else
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);

                    //Explicação
                    //var nome = HttpContext.Request.Form["nome"];
                    //var email = HttpContext.Request.Form["email"];
                    //var texto = HttpContext.Request.Form["texto"];

                    ViewData["MSG_SUCESSO"] = "Mensagem de contato enviada com sucesso!";
                }
            }
            catch (System.Net.Mail.SmtpException)
            {
                ViewData["MSG_ERRO"] = "Usuário e/ou senha incorretos";
            }
            catch (Exception e)
            {
                ViewData["MSG_ERRO"] = "Ocorreu o erro: " + e.Message;

                //TODO: Implementar log.
            }

            return View("Contato");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }

        [ClienteAutorizacao]
        public IActionResult Painel()
        {
            return new ContentResult { Content = "Este é o painel do cliente!"};
        }

        #region POST
        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();

            _clienteRepository.Cadastrar(cliente);

            TempData["MSG_SUCESSO"] = "Cadastro realizado com sucesso!";
            
            //TODO: Implementar redirecionamentos diferentes (Ex: Painel, carrinhos de compras etc)
            return RedirectToAction(nameof(CadastroCliente));
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            var clienteDb = _clienteRepository.Login(cliente.Email, cliente.Senha);

            #region Old
            //Old
            //if (!(cliente.Email == "eveton@teste.com" && cliente.Senha == "1234"))
            //{
            //    return new ContentResult
            //    {
            //        Content = "Não logado!"
            //    };
            //}

            //Old
            //HttpContext.Session.Set("ID", new byte[] { 52 });
            //HttpContext.Session.SetString("Email", cliente.Email); //SetString importar a classe Microsoft.AspNetCore.Http
            //HttpContext.Session.SetInt32("Idade", 41); //SetInt32 importar a classe Microsoft.AspNetCore.Http

            //return new ContentResult
            //{
            //    Content = "Logado!"
            //};
            #endregion

            if (clienteDb == null)
            {
                ViewData["MSG_ERRO"] = $"E-mail: {cliente.Email} não foi encontrado!";
                return View();
            }
                
                //return new ContentResult
                //{
                //    Content = "Não logado!"
                //};

            _loginCliente.Login(clienteDb);

            return new RedirectResult(Url.Action(nameof(Painel)));

          
        }
        #endregion
    }
}