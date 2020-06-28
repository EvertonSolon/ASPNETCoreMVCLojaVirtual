using X.PagedList;

namespace LojaVirtual.Repositorios.Contracts.Base
{
    public interface IBasePagedList<T> where T : class
    {
        IPagedList<T> ObterTodos(int? pagina);
        IPagedList<T> ObterTodos(int? pagina, string pesquisa);
        IPagedList<T> ObterTodos(int? pagina, string pesquisa, string ordenacao);
    }
}
