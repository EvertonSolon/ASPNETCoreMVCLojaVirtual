using LojaVirtual.Bibliotecas.Lang;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Modelos
{
    public class Colaborador : BasePessoa
    {
        /// <summary>
        /// C = Comum e G = Gerente
        /// </summary>
        //[Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Tipo { get; set; }
    }
}
