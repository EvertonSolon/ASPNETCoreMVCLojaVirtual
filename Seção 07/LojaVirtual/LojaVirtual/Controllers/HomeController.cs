using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
                        sb.Append(texto.ErrorMessage);
                        sb.AppendJoin("<br />", texto.ErrorMessage);

                        ViewData["MSG_ERRO"] = sb.ToString();
                    }
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
    }
}