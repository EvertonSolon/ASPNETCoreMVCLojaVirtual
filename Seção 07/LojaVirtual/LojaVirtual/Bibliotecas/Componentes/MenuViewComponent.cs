using LojaVirtual.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Componentes
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public MenuViewComponent(ICategoriaRepository categoriaRepositorio)
        {
            _categoriaRepository = categoriaRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categorias = _categoriaRepository.ObterTodos().ToList();

            return View(categorias);
        }
    }
}
