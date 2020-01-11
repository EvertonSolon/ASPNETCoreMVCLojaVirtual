using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaVirtual.Areas.Colaborador.Controllers.Base
{
    [Area("Colaborador")]
    public class BaseController : Controller
    {
        protected readonly ICategoriaRepository _categoriaRepository;

        public BaseController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        protected void ObterViewBagCategorias()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodos()
                .Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
        }
    }
}