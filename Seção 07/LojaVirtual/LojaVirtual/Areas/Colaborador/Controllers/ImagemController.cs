using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Bibliotecas.Arquivo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ImagemController : Controller
    {
        [HttpPost]
        public IActionResult Armazenar(IFormFile file)
        {
            var caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            if(caminho.Length > 0)
            {
                return Ok(new { caminho }); //JSON
            }

            return new StatusCodeResult(500);
        }

        public IActionResult Excluir(string caminho)
        {
            if (GerenciadorArquivo.ExcluirImagemProduto(caminho))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}