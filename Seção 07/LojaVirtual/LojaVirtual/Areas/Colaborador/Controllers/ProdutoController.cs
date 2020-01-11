using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Areas.Colaborador.Controllers.Base;
using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository) : 
            base(categoriaRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            var resultado = _produtoRepository.ObterTodos(pagina, pesquisa);

            return View(resultado);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ObterViewBagCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Produto produto)
        {
            if (!ModelState.IsValid)
            {
                ObterViewBagCategorias();
                return View();
            }

            _produtoRepository.Cadastrar(produto);
            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var produto = _produtoRepository.Obter(id);
            ObterViewBagCategorias();
            
            return View(produto);
        }

        [HttpPost]
        public IActionResult Atualizar(Produto produto, int id)
        {
            if (!ModelState.IsValid)
            {
                ObterViewBagCategorias();
                return View();
            }

            _produtoRepository.Atualizar(produto);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }
    }
}