using LojaVirtual.Bibliotecas.Validacao;
using LojaVirtual.Modelos.Bases;


namespace LojaVirtual.Modelos
{
    public class Colaborador : LoginBase
    {
        /// <summary>
        /// C = Comum e G = Gerente
        /// </summary>
        //[Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Tipo { get; set; }
    }
}
