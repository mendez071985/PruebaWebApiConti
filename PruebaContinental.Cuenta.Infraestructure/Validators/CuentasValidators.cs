using FluentValidation;
using PruebaContinental.Cuenta.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Cuenta.Infraestructure.Validators
{
    public class CuentasValidators : AbstractValidator<CuentasDto>
    {
        public CuentasValidators()
        {
            RuleFor(cuenta => cuenta.Codigo)
                .NotNull()
                .Length(2, 10);
            RuleFor(cuenta => cuenta.Nombre)
                .NotNull()
                .Length(3, 50);
            RuleFor(cuenta => cuenta.CodigoCliente)
                .NotNull()
                .Length(3, 10);
            RuleFor(cuenta => cuenta.Estado)
                .NotNull()
                .Length(1, 1);
            RuleFor(cuenta => cuenta.Saldo)
                .NotNull();
            RuleFor(cuenta => cuenta.Tipo)
                .NotNull();
        }

    }
}
