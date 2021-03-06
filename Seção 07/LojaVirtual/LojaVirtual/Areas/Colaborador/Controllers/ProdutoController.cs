﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Areas.Colaborador.Controllers.Base;
using LojaVirtual.Bibliotecas.Arquivo;
using LojaVirtual.Bibliotecas.Filtro;
using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ProdutoController : BaseController
    {
        protected readonly IImagemRepository _imagemRepositorio;
        protected readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepositorio,
            ICategoriaRepository categoriaRepositorio,
            IImagemRepository imagemRepositorio) : base(categoriaRepositorio)
        {
            _produtoRepository = produtoRepositorio;
            _imagemRepositorio = imagemRepositorio;

        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            var resultado = _produtoRepository.ObterTodos(pagina, pesquisa);

            return View(resultado);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            GerenciadorArquivo.ApagarTodasImagensTemporarias();
            ObterViewBagCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Produto produto)
        {
            if (!ModelState.IsValid)
            {
                produto.Imagens = new List<string>(Request.Form["imagem"])
                    .Where(x => x.Length > 0)
                    .Select(x => new Imagem { Caminho = x }).ToList();

                ObterViewBagCategorias();
                return View(produto);
            }

            _produtoRepository.Cadastrar(produto);

            var listaCaminhosImagensTemporarias = Request.Form["imagem"].ToList();
            var listaImagensCaminhosDefinitivos = GerenciadorArquivo.MoverImagensProduto(listaCaminhosImagensTemporarias, produto.Id);

            _imagemRepositorio.CadastrarImagens(listaImagensCaminhosDefinitivos);

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
                produto.Imagens = new List<string>(Request.Form["imagem"])
                    .Where(x => x.Length > 0)
                    .Select(x => new Imagem { Caminho = x }).ToList();

                ObterViewBagCategorias();
                return View(produto);
            }

            _produtoRepository.Atualizar(produto);

            var listaCaminhosImagensTemporarias = Request.Form["imagem"].ToList();
            var listaImagensCaminhosDefinitivos = GerenciadorArquivo.MoverImagensProduto(listaCaminhosImagensTemporarias, produto.Id);

            _imagemRepositorio.ExcluirImagensDoProduto(produto.Id);

            _imagemRepositorio.CadastrarImagens(listaImagensCaminhosDefinitivos);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ValidateHttpReferer]
        public IActionResult Excluir(int id)
        {
            var produto = _produtoRepository.Obter(id);

            GerenciadorArquivo.ExcluirImagensProduto(produto.Imagens.ToList());

            _imagemRepositorio.ExcluirImagensDoProduto(id);

            _produtoRepository.Excluir(id);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO_EXCLUSAO;

            return RedirectToAction(nameof(Index));
        }
    }
}