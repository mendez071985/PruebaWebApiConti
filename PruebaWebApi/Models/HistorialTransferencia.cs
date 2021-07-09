using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Models
{
    public class HistorialTransferencia
    {
        public String NombreBeneficiario { get; set; }
        public String CuentaBeneficiario { get; set; }
        public String DocumentoBeneficiario { get; set; }
        public String NombreRemitente { get; set; }
        public String CuentaRemitente { get; set; }
        public String DocumentoRemitente { get; set; }
        public Double Monto { get; set; }
        public String Motivo { get; set; }
        public String Fecha { get; set; }
    }
}
