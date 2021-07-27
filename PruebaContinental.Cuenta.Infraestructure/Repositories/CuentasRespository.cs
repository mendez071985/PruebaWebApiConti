using Microsoft.EntityFrameworkCore;
using PruebaContinental.Cuenta.Core.Entities;
using PruebaContinental.Cuenta.Infraestructure.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PruebaContinental.Cuenta.Core.Interfaces;

namespace PruebaContinental.Cuenta.Infraestructure.Repositories
{
    public class CuentasRespository : ICuentasRespository
    {
        private readonly CuentaContext _context;
        public CuentasRespository(CuentaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cuentas>> Cuentas()
        {
            var cuenta = await _context.Cuenta.ToListAsync();
            return cuenta;
        }

        public async Task InsCuenta(Cuentas cuenta)
        {
            var countCuenta = (from p in _context.Cuenta
                               where p.Codigo.Trim() == cuenta.Codigo.Trim()
                               select p);

            if (countCuenta.Count() == 0)
            {
                var countId = (from p in _context.Cuenta
                               select p);
                cuenta.Id = countId.Max(x => x.Id) + 1;
                _context.Cuenta.Add(cuenta);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Cuentas> Cuenta(string codigo)
        {
            var cuenta = _context.Cuenta.FirstOrDefaultAsync(x => x.Codigo.Trim() == codigo.Trim());

            return await cuenta;
        }

        public async Task<bool> UpdCuenta(Cuentas cuenta)
        {
            var currentCuenta = await Cuenta(cuenta.Codigo);
            currentCuenta.Codigo = cuenta.Codigo;
            currentCuenta.Nombre = cuenta.Nombre;
            currentCuenta.Estado = cuenta.Estado;
            currentCuenta.CodigoCliente = cuenta.CodigoCliente;
            currentCuenta.Estado = cuenta.Estado;
            currentCuenta.Tipo = cuenta.Tipo;
            currentCuenta.Saldo = cuenta.Saldo;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCuenta(string codigo)
        {
            var currentCuenta = await Cuenta(codigo);
            _context.Cuenta.Remove(currentCuenta);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
