using LojaVirtual.Bibliotecas.Login;
using LojaVirtual.Modelos.Contantes;
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

        public ColaboradorAutorizacaoAttribute(string tipoColaboradorAutorizado = ColaboradorTipoConstante.Comum)
        {
            _tipoColaboradorAutorizado = tipoColaboradorAutorizado;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));

            var colaborador = _loginColaborador.GetColaborador();

            if (colaborador == null)
                context.Result = new RedirectToActionResult("Login", "Home", null);
            else if(colaborador.Tipo == ColaboradorTipoConstante.Comum && _tipoColaboradorAutorizado == ColaboradorTipoConstante.Gerente)
                context.Result = new ForbidResult();

        }
    }
}

