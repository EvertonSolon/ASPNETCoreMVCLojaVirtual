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

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        //private readonly LojaVirtualContext _contexto;
        private readonly IClienteRepository _clienteRepository;
        private readonly INewsLetterRepository _newsLetterRepository;

        public HomeController(IClienteRepository clienteRepository, INewsLetterRepository newsLetterRepository)
        {
            _clienteRepository = clienteRepository;
            _newsLetterRepository = newsLetterRepository;
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
            return View();
        }
        #endregion
    }
}