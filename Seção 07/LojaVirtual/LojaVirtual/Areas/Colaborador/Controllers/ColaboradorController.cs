using System;
using System.Linq;
using LojaVirtual.Bibliotecas.Email;
using LojaVirtual.Bibliotecas.Filtro;
using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Bibliotecas.Texto;
using LojaVirtual.Controllers.Contracts;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    //[ColaboradorAutorizacao]
    public class ColaboradorController : Controller, ICrud<Modelos.Colaborador>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public IActionResult GerarSenha(int id)
        {
            var objeto = _colaboradorRepository.Obter(id);
            var randomSTring = GeradorDeChaves.RandomString(8);
            var getUniqueKey = GeradorDeChaves.GetUniqueKey(8);
            var getUniqueKeyOriginal = GeradorDeChaves.GetUniqueKeyOriginal_BASED(8);

            objeto.Senha = getUniqueKey;

            _colaboradorRepository.Atualizar(objeto);
                       

            return null;
        }

        public IActionResult Atualizar(int Id)
        {
            var resultado = _colaboradorRepository.Obter(Id);

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Modelos.Colaborador model, int Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _colaboradorRepository.Atualizar(model);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Colaboradores = _colaboradorRepository.ObterTodos().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        public IActionResult Cadastrar([FromForm] Modelos.Colaborador model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            model.Tipo = "C";
            _colaboradorRepository.Cadastrar(model);
            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int Id)
        {
            _colaboradorRepository.Excluir(Id);
            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO_EXCLUSAO;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index(int? pagina)
        {
            var resultado = _colaboradorRepository.ObterTodos(pagina);

            return View(resultado);
        }
    }
}