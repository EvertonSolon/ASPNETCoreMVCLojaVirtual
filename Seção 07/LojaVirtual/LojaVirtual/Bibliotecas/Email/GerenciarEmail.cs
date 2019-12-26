using LojaVirtual.Modelos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Email
{
    public class GerenciarEmail
    {
        private readonly SmtpClient _smtp;
        protected readonly IOptions<EmailConfiguracao> _emailConfiguracoes;

        public GerenciarEmail(SmtpClient smtp, IOptions<EmailConfiguracao> emailConfiguracoes)
        {
            _smtp = smtp;
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
            try
            {
                var corpoMsg = new StringBuilder();
                corpoMsg.Append("<h2>Contato - Loja Virtual</h2>");
                corpoMsg.Append($"<p><b>Nome:</b> {contato.Nome}</p>");
                corpoMsg.Append($"<p><b>E-mail:</b> {contato.Email}</p>");
                corpoMsg.Append($"<p><b>Texto:</b> {contato.Texto}</p>");
                corpoMsg.Append("<p>E-mail enviado automaticamente do site Loja Virtual</p>");


                var mensagem = new MailMessage
                {
                    From = new MailAddress(_emailConfiguracoes.Value.UserName, "Everton Remetente"),
                    Subject = $"Contato - Loja Virtual - Email: {contato.Email}",
                    Body = corpoMsg.ToString(),
                    IsBodyHtml = true
                };

                mensagem.To.Add(new MailAddress("evertonsolon@gmail.com", "Everton Destinatário"));

                _smtp.Send(mensagem);
            }
            catch (SmtpException smtpException)
            {
                throw smtpException;
            }
        }

        public void EnviarSenhaParaColaboradorPorEmail(Colaborador colaborador)
        {
            var corpoMsg = new StringBuilder();
            corpoMsg.Append("<h2>Colaborador - Loja Virtual</h2>");
            corpoMsg.Append($"<p><b>Nome:</b> {colaborador.Nome}</p>");
            corpoMsg.Append($"<p><b>E-mail:</b> {colaborador.Email}</p>");
            corpoMsg.Append($"<p><b>Sua senha é:</b> {colaborador.Senha}</p>");
            corpoMsg.Append("<p>E-mail enviado do site Loja Virtual</p>");

            try
            {
                var mensagem = new MailMessage
                {
                    From = new MailAddress(_emailConfiguracoes.Value.UserName, "Everton Remetente"),
                    Subject = $"Colaborador - Loja Virtual - Senha do colaborador: {colaborador.Nome}",
                    Body = corpoMsg.ToString(),
                    IsBodyHtml = true
                };

                mensagem.To.Add(new MailAddress(colaborador.Email));

                _smtp.Send(mensagem);
            }
            catch(FormatException formatException)
            {
                if (formatException.Message.Contains("form required for an e-mail address"))
                    throw new FormatException("Usuário do e-mail no formato incorreto!");

                throw;
            }
            catch (SmtpException smtpException)
            {
                if (smtpException.Message.Contains("Authentication Required"))
                    throw new SmtpException("Verifique o usuário e / ou senha da autentiação ou a configuração de acesso a app menos seguro!");

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
