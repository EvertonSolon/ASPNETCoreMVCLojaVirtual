using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Bibliotecas.Filtro;
using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Modelos;
using LojaVirtual.Modelos.Contantes;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index(int? pagina, string pesquisa)
        {
            return View(_clienteRepository.ObterTodos(pagina, pesquisa));
        }

        [ValidateHttpReferer]
        public IActionResult AtivarDesativar(int id)
        {
            var cliente = _clienteRepository.Obter(id);

            cliente.Situacao = cliente.Situacao == SituacaoConstante.Ativo ? SituacaoConstante.Desativado : SituacaoConstante.Ativo;
            _clienteRepository.Atualizar(cliente);

            TempData["MSG_SUCESSO"] = Mensagem.MSG_SUCESSO_ATUALIZADO;

            return RedirectToAction(nameof(Index));
        }
    }
}