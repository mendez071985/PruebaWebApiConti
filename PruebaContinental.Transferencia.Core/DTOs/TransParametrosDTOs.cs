using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Transferencia.Core.DTOs
{
    public class TransParametrosDTOs
    {
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public string Motivo { get; set; }
        public double monto { get; set; }
    }
}
