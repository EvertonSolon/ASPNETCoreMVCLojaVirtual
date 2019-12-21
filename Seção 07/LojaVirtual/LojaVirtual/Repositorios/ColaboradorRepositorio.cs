using LojaVirtual.BaseDeDados;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositorios
{
    public class ColaboradorRepositorio : BaseRepositorio, IColaboradorRepository
    {
        public ColaboradorRepositorio(LojaVirtualContext contexto) : base(contexto)
        {

        }

        public void Atualizar(Colaborador model)
        {
            _contexto.Update(model);
            _contexto.SaveChanges();
        }

        public void Cadastrar(Colaborador model)
        {
            _contexto.Add(model);
            _contexto.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var objeto = Obter(Id);
            _contexto.Remove(objeto);
            _contexto.SaveChanges();
        }

        public Colaborador Login(string email, string senha)
        {
            var objeto = _contexto.Colaboradores.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            return objeto;
        }

        public Colaborador Obter(int Id)
        {
            return _contexto.Colaboradores.Find(Id);
        }

        public IEnumerable<Colaborador> ObterTodos()
        {
            return _contexto.Colaboradores.ToList();
        }

    }
}
