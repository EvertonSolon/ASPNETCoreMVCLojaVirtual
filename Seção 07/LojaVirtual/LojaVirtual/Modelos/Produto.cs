using LojaVirtual.Bibliotecas.Lang;
using LojaVirtual.Modelos.Bases;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Modelos
{
    public class Produto : Base
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public decimal Valor { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(0, 1000000, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_FORA_DO_LIMITE")]
        public int Quantidade { get; set; }

        //Frete
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(0.001, 30, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_FORA_DO_LIMITE")]
        public double Peso { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(11, 105, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_FORA_DO_LIMITE")]
        public int Largura { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(2, 105, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_FORA_DO_LIMITE")]
        public int Altura { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(16, 105, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_FORA_DO_LIMITE")]
        public int Comprimento { get; set; }

        /*
         * EF - ORM  - Biblioteca que serve para unir o Banco de dados e POO. (ORM - Mapeamento de objetos <-> Relacionamentos)
         *Fluent API -  Attributes
         */

        //Banco de dados - Relacionamentos entre tabelas
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [ForeignKey("Categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        //POO - Associações entre objetos
        //[ForeignKey("CategoriaId")] ou um ou outro
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }
    }
}
