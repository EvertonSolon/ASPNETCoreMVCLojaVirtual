using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorios.Contracts
{
    interface IImagemRepository : IBaseCrudRepository<Imagem>, IBasePagedList<Imagem>
    {
        void ExcluirImagensDoProduto(int ProdutoId);
    }
}
