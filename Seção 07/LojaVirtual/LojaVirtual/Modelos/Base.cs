using LojaVirtual.Bibliotecas.Lang;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Modelos
{
    public class Base
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Nome { get; set; }
    }
}
