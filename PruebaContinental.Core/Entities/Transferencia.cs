using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Core.Entities
{
    public class Transferencia
    {
        public double Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double Monto { get; set; }
        public string Concepto { get; set; }
    }
}
