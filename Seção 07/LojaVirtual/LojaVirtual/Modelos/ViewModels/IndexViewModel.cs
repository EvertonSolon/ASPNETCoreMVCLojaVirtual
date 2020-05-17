using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Modelos.ViewModels
{
    public class IndexViewModel
    {
        public NewsLetterEmail newsLetter { get; set; }
        public IPagedList<Produto> lista { get; set; }
    }
}
