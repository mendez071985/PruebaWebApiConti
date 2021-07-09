using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Interfaces
{
    public interface ICuenta
    {
        Cuentas registrar(Cuentas cuenta);
        string borrar(int id);
        Cuentas modificar(Cuentas modificarCuenta);
    }
}
