using FluentValidation;
using PruebaContinental.Transferencia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Transferencia.Infraestructure.Validators
{
    public class TransferenciaValidators : AbstractValidator<TransParametrosDTOs>
    {
        public TransferenciaValidators()
        {
            RuleFor(transferencia => transferencia.CuentaDestino)
                .NotNull()
                .Length(2, 10);
            RuleFor(transferencia => transferencia.CuentaOrigen)
                .NotNull()
                .Length(2, 10);
            RuleFor(transferencia => transferencia.monto)
                .NotNull();
        }
    }
}
