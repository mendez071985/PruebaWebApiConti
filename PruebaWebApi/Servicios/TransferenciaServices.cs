using Microsoft.EntityFrameworkCore;
using PruebaWebApi.Entities;
using PruebaWebApi.Interfaces;
using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Servicios
{
    public class TransferenciaServices: ITransferencia
    {
        private readonly PostDbContext postDbContext;
        public TransferenciaServices(PostDbContext postDbContext)
        {
            this.postDbContext = postDbContext;
        }
        public String transferencia(SolicitudTransferencia solicitudTransferencia)
        {
            var mensaje = "OK";
            var secuenciea = (from i in postDbContext.SolicitudTransferencias select new { i.Id}).ToList().Count ;
            try 
            {
                var benificiario = (from pd in postDbContext.Clientes
                                    join od in postDbContext.Cuentas on pd.Codigo equals od.CodigoCliente
                                    where od.Cuenta == solicitudTransferencia.CuentaBeneficiario
                                    && od.Estado == "A"
                                    select new
                                    {
                                        pd.Nombre,
                                        pd.Apellido,
                                        pd.Codigo,
                                        pd.NumeroDocumento,
                                        pd.TipoDocumento,
                                        od.Cuenta,
                                        od.Saldo
                                    }).ToList();

                if (benificiario.Count > 0)
                {
                    var remitente = (from pd in postDbContext.Clientes
                                     join od in postDbContext.Cuentas on pd.Codigo equals od.CodigoCliente
                                     where od.Cuenta == solicitudTransferencia.CuentaRemitente
                                     && od.Estado == "A"
                                     select new
                                     {
                                         pd.Nombre,
                                         pd.Apellido,
                                         pd.Codigo,
                                         pd.NumeroDocumento,
                                         pd.TipoDocumento,
                                         od.Cuenta,
                                         od.Saldo
                                     }).ToList();

                    if (remitente.Count() > 0)
                    {
                        if (remitente[0].Saldo > 0)
                        {
                            if (remitente[0].Saldo > solicitudTransferencia.Monto) {

                                var queryRemitente = (from a in postDbContext.Cuentas
                                             where a.Cuenta == solicitudTransferencia.CuentaRemitente
                                             select a).FirstOrDefault();

                                queryRemitente.Saldo = queryRemitente.Saldo - solicitudTransferencia.Monto;
                                var modifiCuentaRemitente = postDbContext.Cuentas.Attach(queryRemitente);
                                modifiCuentaRemitente.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                postDbContext.SaveChanges();
                                ;  
                                
                                //modifica  cambios

                                var queryBeneficiario = (from a in postDbContext.Cuentas
                                                      where a.Cuenta == solicitudTransferencia.CuentaBeneficiario
                                                      select a).FirstOrDefault();

                                queryBeneficiario.Saldo = queryRemitente.Saldo + solicitudTransferencia.Monto;

                                var modifiCuentaBeneficiario = postDbContext.Cuentas.Attach(queryBeneficiario);
                                modifiCuentaBeneficiario.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                postDbContext.SaveChanges();

                                // postDbContext.SaveChanges();
                                ;  //modifica  cambios

                                SolicitudTransferencia nuevaTransferencia = new SolicitudTransferencia();
                                nuevaTransferencia.Id = secuenciea + 1;
                                nuevaTransferencia.CuentaBeneficiario = solicitudTransferencia.CuentaBeneficiario;
                                nuevaTransferencia.NombreBeneficiario = solicitudTransferencia.NombreBeneficiario;
                                nuevaTransferencia.DocumentoBeneficiario= solicitudTransferencia.DocumentoBeneficiario;
                                nuevaTransferencia.CuentaRemitente = solicitudTransferencia.CuentaRemitente;
                                nuevaTransferencia.NombreRemitente = solicitudTransferencia.NombreRemitente;
                                nuevaTransferencia.DocumentoRemitente = solicitudTransferencia.DocumentoRemitente;
                                nuevaTransferencia.Fecha = DateTime.Now.ToString();
                                nuevaTransferencia.Motivo = solicitudTransferencia.Motivo;
                                nuevaTransferencia.Monto = solicitudTransferencia.Monto;

                                postDbContext.SolicitudTransferencias.Add(nuevaTransferencia);
                                postDbContext.SaveChanges();
                            }
                            else
                            {
                                throw new InvalidOperationException("El remitente no posee saldo suficiente");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("El remitente no posee saldo");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("No existe remitente");
                    }
                }
                else
                {
                    throw new InvalidOperationException("No existe beneficiario");
                }
                return mensaje;
            }
            catch(Exception ex) {
                throw new Exception("Mensaje.", ex);

            }

        }
        
    }
}
