using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaContinental.Transferencia.Core.Entities
{
    public class Transferencias
    {
        public double Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double Monto { get; set; }
        public Conceptos? Concepto { get; set; }
    }     

    // concepto Type Enum
    public enum Conceptos
    {
        Enfermedad,
        Familiar,
        Gastos
    }

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
