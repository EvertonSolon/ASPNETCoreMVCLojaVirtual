using System;
using LojaVirtual.Controllers.Contracts;
using LojaVirtual.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    public class ColaboradorController : Controller, ICrud<Modelos.Colaborador>
    {
        public IActionResult Atualizar(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Atualizar([FromForm] Modelos.Colaborador model, int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Cadastrar()
        {
            throw new NotImplementedException();
        }

        public IActionResult Cadastrar([FromForm] Modelos.Colaborador model)
        {
            throw new NotImplementedException();
        }

        public IActionResult Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index(int? pagina)
        {
            throw new NotImplementedException();
        }
    }
}