using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Interfaces
{
    public interface ICliente
    {
        Cliente registrar(Cliente cliente);
        string borrar(int id);
        Cliente modificar(Cliente modificarcliente);
    }
}
