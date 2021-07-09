using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Models
{
    public class Cuentas
    {
        [Key]
        public int Id { get; set; }
        public Double CodigoCliente { get; set; }
        public String NumeroDocumento { get; set; }
        public String Cuenta { get; set; }
        public String Sucursal { get; set; }
        public String Nombre { get; set; }
        public String Estado { get; set; }
        public Double Saldo { get; set; }

    }
}
