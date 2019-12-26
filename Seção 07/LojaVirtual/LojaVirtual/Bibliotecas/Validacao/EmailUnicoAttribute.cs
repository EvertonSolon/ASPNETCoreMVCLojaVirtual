using LojaVirtual.BaseDeDados;
using LojaVirtual.Modelos;
using LojaVirtual.Repositorios.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Bibliotecas.Validacao
{
    public class EmailUnicoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = (value as string).Trim();
            bool jaExisteEmail = false;
            var tipoObjeto = validationContext.ObjectType;

            if (tipoObjeto == typeof(Colaborador))
            {
                //Tentativa 1
                var _repositorio = validationContext.GetService(typeof(IColaboradorRepository)) as IColaboradorRepository;
                var resultados = _repositorio.ObterPorEmail(email);
                var objeto = validationContext.ObjectInstance as Colaborador;
                jaExisteEmail = ValidarExistenciaEmail(resultados.Count, objeto.Id, resultados.Any() ? resultados[1]?.Id : null);
            }
            else if (tipoObjeto == typeof(Cliente))
            {
                var _repositorio = validationContext.GetService(typeof(IClienteRepository)) as IClienteRepository;
                var resultados = _repositorio.ObterPorEmail(email);
                var objeto = validationContext.ObjectInstance as Cliente;
                jaExisteEmail = ValidarExistenciaEmail(resultados.Count, objeto.Id, resultados.Any() ? resultados[0]?.Id : null);
            }

            if (jaExisteEmail)
                return new ValidationResult("E-mail já cadastrado!");
                
            return ValidationResult.Success;
        }

        private bool ValidarExistenciaEmail(int quantidade, int objetoId, int? resultadoId)
        {
            return quantidade > 0 && objetoId != resultadoId;
        }
    }
}
