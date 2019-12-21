using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers.Contracts
{
    public interface ICrud<T> where T : class
    {
        IActionResult Index(int? pagina);

        [HttpGet]
        IActionResult Cadastrar();

        [HttpPost]
        IActionResult Cadastrar([FromForm]T model);

        [HttpGet]
        IActionResult Atualizar(int Id);

        [HttpPost]
        IActionResult Atualizar([FromForm]T model, int Id);

        [HttpGet]
        IActionResult Excluir(int Id);
    }
}
