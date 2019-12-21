using LojaVirtual.Bibliotecas.Lang;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Modelos
{
    public class Categoria : Base
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Slug { get; set; }

        //Auto-relacionamento
        [Display(Name = "Categoria pai")]
        public int? CategoriaPaiId { get; set; }

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }
    }
}
