using LojaVirtual.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            try
            {
                /*
             SMTP -> Servidor que vai enviar a mensagem.
             */
                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("informar o usuário aqui", "informar a senha aqui"),
                    EnableSsl = true
                };

                //Refatorar
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("informar o usuário aqui", "informar a senha aqui");
                //smtp.EnableSsl = true;

                /*
                 MailMessage -> Construir a mensagem.
                 */

                var corpoMsg = new StringBuilder();
                corpoMsg.Append("<h2>Contato - Loja Virtual</h2>");
                corpoMsg.Append($"<p><b>Nome:</b> {contato.Nome}</p>");
                corpoMsg.Append($"<p><b>E-mail:</b> {contato.Email}</p>");
                corpoMsg.Append($"<p><b>Texto:</b> {contato.Texto}</p>");
                corpoMsg.Append("<p>E-mail enviado automaticamente do site Loja Virtual</p>");


                var mensagem = new MailMessage
                {
                    From = new MailAddress("evertonsolon@gmail.com", "Everton Remetente"),
                    Subject = $"Contato - Loja Virtual - Email: {contato.Email}",
                    Body = corpoMsg.ToString(),
                    IsBodyHtml = true
                };

                mensagem.To.Add(new MailAddress("evertonsolon@gmail.com", "Everton Destinatário"));

                smtp.Send(mensagem);
            }
            catch (SmtpException smtpException)
            {
                throw smtpException;
            }
        }
    }
}
