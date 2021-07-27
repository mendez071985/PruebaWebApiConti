using FluentValidation;
using PruebaContinental.Cliente.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Cliente.Infraestructure.Validators
{
    public class ClientesValidators : AbstractValidator<ClientesDto>
    {
        public ClientesValidators()
        {
            RuleFor(cliente => cliente.Codigo)
                .NotNull()
                .Length(2, 10);
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
                .Length(1, 1);
        }

    }
}
