using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Bibliotecas.Filtro;
using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index(int? pagina)
        {
            var categorias = _categoriaRepository.ObterTodos(pagina);

            return View(categorias);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodos().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _categoriaRepository.ObterTodos().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
                return View();
            }
                

            _categoriaRepository.Cadastrar(categoria);
            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            var categoria = _categoriaRepository.Obter(Id);

            ViewBag.Categorias = _categoriaRepository.ObterTodos().Where(x => x.Id != Id).
                Select(x => new SelectListItem(x.Nome, x.Id.ToString()));

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Categoria categoria, int Id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _categoriaRepository.ObterTodos().Where(x => x.Id != Id).
                   Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
                return View();

            }

            _categoriaRepository.Atualizar(categoria);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            _categoriaRepository.Excluir(Id);
            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO_EXCLUSAO;
            return RedirectToAction(nameof(Index));
        }

    }
}