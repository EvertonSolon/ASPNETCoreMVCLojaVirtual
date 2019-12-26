using LojaVirtual.Bibliotecas.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Filtro
{
    /*
     * Tipos de filtros:
     * Autorização
     * Recurso
     * Ação
     * Exceção
     * Resultado
     */

    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginColaborador _loginColaborador;
        private string _tipoColaboradorAutorizado;

        public ColaboradorAutorizacaoAttribute(string tipoColaboradorAutorizado = "C")
        {
            _tipoColaboradorAutorizado = tipoColaboradorAutorizado;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));

            var colaborador = _loginColaborador.GetColaborador();

            if (colaborador == null)
                context.Result = new RedirectToActionResult("Login", "Home", null);
            else if(colaborador.Tipo == "C" && _tipoColaboradorAutorizado == "G")
                context.Result = new ForbidResult();

        }
    }
}

