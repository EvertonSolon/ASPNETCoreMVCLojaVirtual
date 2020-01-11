using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            var cabecalho = context.Request.Headers["x-requested-with"];
            var tipoAjax = cabecalho == "XMLHttpRequest";
            //var existeArquivo = context.Request.Form.Files.Any();

            if (HttpMethods.IsPost(context.Request.Method) && !(context.Request.Form.Files.Any() && tipoAjax))
            {
                await _antiforgery.ValidateRequestAsync(context);
            }
            await _next(context);
        }
    }
}
