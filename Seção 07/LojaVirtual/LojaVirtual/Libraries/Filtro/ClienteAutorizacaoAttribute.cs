﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaVirtual.Libraries.Filtro
{
    /*
     * Tipos de filtros:
     * Autorização
     * Recurso
     * Ação
     * Exceção
     * Resultado
     */

    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {

        private LoginCliente _loginCliente;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));

            var cliente = _loginCliente.GetCliente();

            if (cliente == null)
                context.Result = new ContentResult { Content = "Acesso negado" };
        }
    }
}
