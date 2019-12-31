using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Filtro
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Executado antes passar pelo controlador
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult { Content = "Acesso negado! Referer vazio." };
                return;
            }

            var uri = new Uri(referer);

            var hostReferer = uri.Host;
            var hostServidor = context.HttpContext.Request.Host.Host;

            if (hostReferer != hostServidor)
                context.Result = new ContentResult { Content = "Acesso negado! Referer diferente do servidor."};
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Executado após passar pelo controlador
            
        }

        
    }
}
