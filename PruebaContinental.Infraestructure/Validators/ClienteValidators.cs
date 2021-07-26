using FluentValidation;
using PruebaContinental.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Infraestructure.Validators
{
    public class ClienteValidators : AbstractValidator<ClienteDTOs>
    {
        public ClienteValidators()
        {
            RuleFor(cliente => cliente.Codigo)
                .NotNull()
                .Length(2,10);
            RuleFor(cliente => cliente.Nombre)
                .NotNull()
                .Length(3, 50);
            RuleFor(cliente => cliente.Apellido)
                .NotNull()
                .Length(3, 50);
            RuleFor(cliente => cliente.Direccion)
                .NotNull()
                .Length(3, 50);
            RuleFor(cliente => cliente.Telefono)
                .NotNull()
                .Length(10, 10);
            RuleFor(cliente => cliente.Estado)
                .NotNull()
                .Length(1, 2);
        }
        
    }
}
