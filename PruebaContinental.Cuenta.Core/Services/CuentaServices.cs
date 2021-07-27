using PruebaContinental.Cuenta.Core.Entities;
using PruebaContinental.Cuenta.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaContinental.Cuenta.Core.Services
{
    public class CuentaServices : ICuentaServices
    {
        private readonly ICuentasRespository _iCuentasRepository;
        public CuentaServices(ICuentasRespository iCuentasRepository)
        {
            _iCuentasRepository = iCuentasRepository;
        }

        public async Task<bool> DeleteCuenta(string codigo)
        {
            return await _iCuentasRepository.DeleteCuenta(codigo);
        }

        public async Task<Cuentas> Cuenta(string codigo)
        {
            return await _iCuentasRepository.Cuenta(codigo);
        }

        public async Task<IEnumerable<Cuentas>> Cuentas()
        {
            return await _iCuentasRepository.Cuentas();
        }

        public async Task InsCuenta(Cuentas cuenta)
        {
            var cliInsert = await _iCuentasRepository.Cuenta(cuenta.Codigo);
            if (cliInsert != null)
            {
                throw new Exception("La cuenta ya existe");
            }
            await _iCuentasRepository.InsCuenta(cuenta);
        }

        public async Task<bool> UpdCuenta(Cuentas cuenta)
        {
            return await _iCuentasRepository.UpdCuenta(cuenta);
        }
    }
}
