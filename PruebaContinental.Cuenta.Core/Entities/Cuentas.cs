using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaContinental.Cuenta.Core.Entities
{
    public class Cuentas
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public double? Saldo { get; set; }
        public string Tipo { get; set; }
        public double Id { get; set; }
        public string CodigoCliente { get; set; }
    }
}
