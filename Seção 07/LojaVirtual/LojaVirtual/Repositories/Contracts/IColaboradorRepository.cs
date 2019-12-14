using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string Senha);

        void Cadastrar(Colaborador model);

        void Atualizar(Colaborador model);

        void Excluir(int Id);

        Colaborador Obter(int Id);

        IEnumerable<Colaborador> ObterTodos();
    }
}
