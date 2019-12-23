using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.PagedLlist
{
    public class PagedListConfiguracao
    {
        public PagedListConfiguracao()
        {
            Views = new Views();
        }

        public Views Views { get; }
    }

    public class Views
    {
        public int RegistrosPorPagina { get; set; }
    }
}
