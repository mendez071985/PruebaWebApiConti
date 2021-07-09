using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String NumeroDocumento { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Ocupacion { get; set; }
        public String TipoDocumento { get; set; }
        public Double Codigo { get; set; }

    }
}
