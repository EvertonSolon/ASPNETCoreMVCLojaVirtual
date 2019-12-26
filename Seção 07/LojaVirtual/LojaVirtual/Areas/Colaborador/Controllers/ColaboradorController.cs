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
    //[ColaboradorAutorizacao("G")]
    public class ColaboradorController : Controller, ICrud<Modelos.Colaborador>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly GerenciarEmail _gerenciarEmail;

        public ColaboradorController(IColaboradorRepository colaboradorRepository,
            GerenciarEmail gerenciarEmail)
        {
            _colaboradorRepository = colaboradorRepository;
            _gerenciarEmail = gerenciarEmail;
        }

        [HttpGet]
        public IActionResult GerarSenha(int id)
        {
            var objeto = _colaboradorRepository.Obter(id);

            //Usei as variáveis abaixo para ver o resultado do gerador de chaves.
            var randomSTring = GeradorDeChaves.RandomString(8);
            var getUniqueKey = GeradorDeChaves.GetUniqueKey(8);
            var getUniqueKeyOriginal = GeradorDeChaves.GetUniqueKeyOriginal_BASED(8);

            objeto.Senha = getUniqueKey;

            _colaboradorRepository.Atualizar(objeto);

            _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(objeto);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO_SENHA_ENVIADA;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int Id)
        {
            var resultado = _colaboradorRepository.Obter(Id);
            TempData["Senha"] = resultado.Senha; //Workarround para validação do post.

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Modelos.Colaborador model, int Id)
        {
            ModelState.Remove(nameof(model.Senha));
            ModelState.Remove(nameof(model.ConfirmacaoSenha));

            if (!ModelState.IsValid)
            {
                return View();
            }
            
            model.Senha = TempData["Senha"].ToString();

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

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Modelos.Colaborador model)
        {
            ModelState.Remove(nameof(model.Senha));
            ModelState.Remove(nameof(model.ConfirmacaoSenha));

            if (!ModelState.IsValid)
            {
                return View();
            }


            model.Tipo = "C";
            model.Senha = GeradorDeChaves.GetUniqueKey(8);
            _colaboradorRepository.Cadastrar(model);
            _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(model);

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