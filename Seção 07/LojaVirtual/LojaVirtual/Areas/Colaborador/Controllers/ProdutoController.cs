using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            var resultado = _produtoRepository.ObterTodos(pagina, pesquisa);

            return View(resultado);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodos()
                .Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        public IActionResult Cadastrar([FromForm]Produto produto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Produtos = _produtoRepository.ObterTodos()
                    .Select(x => new SelectListItem(x.Id.ToString(), 
                                                    x.Nome));
                return View();
            }

            _produtoRepository.Cadastrar(produto);
            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }
    }
}