using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Transferencia.Core.DTOs
{
    public class TransferenciaReporteDTOs
    {
        public string Cuenta { get; set; }
       // public string Destino { get; set; }
        public double Monto { get; set; }
        public string Concepto { get; set; }
        public string  TipoTransferencia { get; set; }

    }
}
