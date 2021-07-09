using PruebaWebApi.Entities;
using PruebaWebApi.Interfaces;
using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Servicios
{
    public class CuentaServices:ICuenta
    {
        private readonly PostDbContext postDbContext;
        public CuentaServices(PostDbContext postDbContext)
        {
            this.postDbContext = postDbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public Cuentas registrar(Cuentas cuenta)
        {
            try { 
                var client = postDbContext.Cuentas.Where(x => x.Cuenta == cuenta.Cuenta).Count();
                cuenta.Id = postDbContext.Cuentas.Count() + 1;
                if (client == 0)
                {
                    postDbContext.Cuentas.Add(cuenta);
                    postDbContext.SaveChanges();
                }
                else
                {
                throw new InvalidOperationException("La cuenta ya existe.");

                }
            }
            catch
            {
                throw;
            }
            return cuenta;
        }
        public string borrar(int id)
        {
            var existe = "";
            try
            {

                Cuentas cuenta = postDbContext.Cuentas.Find(id);
                if (cuenta != null)
                {
                    postDbContext.Cuentas.Remove(cuenta);
                    postDbContext.SaveChanges();
                    existe = "La cuenta ha sido borrada.";

                }
                else
                {
                    existe = "La cuenta no ha sido borrado o no existe.";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }
        public Cuentas modificar(Cuentas modificarCuenta)
        {
            try
            {
                var client = postDbContext.Cuentas.Attach(modificarCuenta);
                client.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                postDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("El clinte no ha sido modificado.");
            }
            return modificarCuenta;

        }

        public string estadoCuenta(String cuenta)
        {
            var estadoCuenta = "";
            var benificiario = (from pd in postDbContext.Cuentas
                                where pd.Cuenta == cuenta
                                select new { pd.Estado }
                                ).ToList();

            if (benificiario[0].Estado == "A")
            {
                estadoCuenta = "La Cuenta es Activo";
            }
            else
            {
                estadoCuenta = "La cuenta no exsite o esta inactivo";
            }
            return estadoCuenta;
        }

    }
}
