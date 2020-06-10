using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Modelos.ViewModels
{
    public class IndexViewModel
    {
        public NewsLetterEmail NewsLetter { get; set; }
        public IPagedList<Produto> Lista { get; set; }
        public List<SelectListItem> OrdenacaoLista
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem("Alfabética", "A"),
                    new SelectListItem("Menor preço", "ME"),
                    new SelectListItem("Maior preço", "MA"),
                };
            }
            private set { }
        }
    }
}
