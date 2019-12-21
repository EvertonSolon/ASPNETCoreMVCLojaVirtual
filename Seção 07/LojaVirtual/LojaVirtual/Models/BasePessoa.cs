using LojaVirtual.Libraries.Lang;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class BasePessoa : Base
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Senha { get; set; }

        /// <summary>
        /// Válido somente no formulário para validar o campo senha. Não é necessário atualizar o banco pelo Migration 
        /// porque não terá uma coluna na tabela Colaborador.
        /// </summary>
        [NotMapped]
        [Display(Name = "Confirmação da senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
