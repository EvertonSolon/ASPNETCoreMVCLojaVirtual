using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Visualizar()
        {
            var produto = GetProduto();

            return View(produto);
            //return new ContentResult {Content = "<h3>Produtos teste</h3>", ContentType = "text/html"};
        }

        private Produto GetProduto()
        {
            return new Produto
            {
                Id = 1,
                Nome = "XBox",
                Descricao = "Jogue bla bla",
                Valor = 200.00M
            };
        }

    }
}