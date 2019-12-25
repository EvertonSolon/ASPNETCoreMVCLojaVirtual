using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Email
{
    public class EmailConfiguracao
    {
        public string ServerSMTP { get; set; }
        public int ServerPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
