using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Controllers.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

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
            var form = HttpContext.Request.Form;

            var contato = new Contato
            {
                Nome = form["nome"],
                Email = form["email"],
                Texto = form["texto"]
            };

            ContatoEmail.EnviarContatoPorEmail(contato);

            //Explicação
            //var nome = HttpContext.Request.Form["nome"];
            //var email = HttpContext.Request.Form["email"];
            //var texto = HttpContext.Request.Form["texto"];
            return new ContentResult
            {
                Content = "Dados recebidos com sucesso! " +
                $"<p>Nome: {contato.Nome}</p> <p>Email: {contato.Email}</p> <p>Texto: {contato.Texto}</p>",
                ContentType = "text/html"
            };
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