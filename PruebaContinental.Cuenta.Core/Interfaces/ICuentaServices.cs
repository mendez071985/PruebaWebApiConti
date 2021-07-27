using PruebaContinental.Cuenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Cuenta.Core.Interfaces
{
    public interface ICuentaServices
    {
        Task<IEnumerable<Cuentas>> Cuentas();
        Task InsCuenta(Cuentas cuenta);
        Task<Cuentas> Cuenta(string codigo);
        Task<bool> UpdCuenta(Cuentas cuenta);
        Task<bool> DeleteCuenta(string codigo);
    }
}
