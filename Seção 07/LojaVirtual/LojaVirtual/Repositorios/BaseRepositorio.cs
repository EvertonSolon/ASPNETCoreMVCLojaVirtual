using LojaVirtual.BaseDeDados;
using LojaVirtual.Bibliotecas.PagedLlist;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LojaVirtual.Repositorios
{
    public class BaseRepositorio
    {
        protected readonly LojaVirtualContext _contexto;
        //protected readonly IOptions<PagedListConfiguracao> _pagedListConfiguracoes;
        protected readonly int _RegistrosPorPagina;

        public BaseRepositorio(LojaVirtualContext contexto, IOptions<PagedListConfiguracao> pagedListConfiguracoes)
        {
            _contexto = contexto;
            //_pagedListConfiguracoes = pagedListConfiguracoes;
            _RegistrosPorPagina = pagedListConfiguracoes.Value.Views.RegistrosPorPagina;
        }
    }
}
