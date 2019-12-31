using LojaVirtual.Modelos.Bases;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Modelos
{
    public class Produto : Base
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        //Frete
        public double Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }

        /*
         * EF - ORM  - Biblioteca que serve para unir o Banco de dados e POO. (ORM - Mapeamento de objetos <-> Relacionamentos)
         *Fluent API -  Attributes
         */

        //Banco de dados - Relacionamentos entre tabelas
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        //POO - Associações entre objetos
        //[ForeignKey("CategoriaId")] ou um ou outro
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }
    }
}
