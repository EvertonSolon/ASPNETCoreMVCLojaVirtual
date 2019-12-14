using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository colaboradorRepository, LoginColaborador loginColaborador)
        {
            _colaboradorRepository = colaboradorRepository;
            _loginColaborador = loginColaborador;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Models.Colaborador colaboradfor)
        {
            var colaboradorDb = _colaboradorRepository.Login(colaboradfor.Email, colaboradfor.Senha);
                       
            if (colaboradorDb == null)
            {
                ViewData["MSG_ERRO"] = $"E-mail: {colaboradfor.Email} não foi encontrado!";
                return View();
            }
                       
            _loginColaborador.Login(colaboradorDb);

            return new RedirectResult(Url.Action(nameof(Painel)));
        }

        [ColaboradorAutorizacaoAttribute]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

        public IActionResult CadastrarNovaSenha()
        {
            return View();
        }

        [ColaboradorAutorizacaoAttribute]
        public IActionResult Painel()
        {
            return View();
        }
    }
}