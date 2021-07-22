using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Core.Entities
{
    public class Historial
    {
        public double Codigo { get; set; }
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public double? Monto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
