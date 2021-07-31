using PruebaContinental.Transferencia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using PruebaContinental.Transferencia.Core.DTOs;
using PruebaContinental.Transferencia.Core.Entities;
using PruebaContinental.Transferencia.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PruebaContinental.Transferencia.Infraestructure.Repositories
{
    public class TransferenciasRepository : ITransferenciasRepository

    {
        bool check = false;
        private readonly TransferenciaContext _context;
        public TransferenciasRepository(TransferenciaContext context)
        {
            _context = context;
        }

        public async Task<string> transferencia(TransParametrosDTOs TransParam)
        {

            var mensaje = "Transferencia realizada";
            var secuencia = _context.Transferencia.ToList().Count();
            var origen = (from pd in _context.Cliente
                          join od in _context.Cuenta on pd.Codigo equals od.CodigoCliente
                          where od.Codigo == TransParam.CuentaOrigen
                          && od.Estado == "A"
                          select new
                          {
                              Nombre = pd.Nombre,
                              Apellido = pd.Apellido,
                              IdCliente = pd.Codigo,
                              Cuenta = pd.Codigo,
                              Saldo = od.Saldo
                          }).ToList();

            if (origen.Count > 0)
            {
                var destino = (from pd in _context.Cliente
                               join od in _context.Cuenta on pd.Codigo equals od.CodigoCliente
                               where od.Codigo == TransParam.CuentaDestino
                               && od.Estado == "A"
                               select new
                               {
                                   Nombre = pd.Nombre,
                                   Apellido = pd.Apellido,
                                   IdCliente = pd.Codigo,
                                   Cuenta = pd.Codigo,
                                   Saldo = od.Saldo
                               }).ToList();

                if (destino.Count > 0)
                {
                    Conceptos motivo = new Conceptos();

                    foreach (string emn in Enum.GetNames(typeof(Conceptos)))
                    {
                        // Debug.Log(":: " + emn );

                        if (emn.ToUpper().Trim() == TransParam.Motivo.ToUpper().Trim())
                        {
                            motivo = (Conceptos)Enum.Parse(typeof(Conceptos), TransParam.Motivo.ToUpper().Trim(), true);

                            check = true;
                        }

                    };

                    if (check == false)
                    {
                        throw new Exception("El motivo ingresado no existe, debe ser: Enfermedad , Familiar, Gastos");
                    }


                    if (origen[0].Saldo > 0 && origen[0].Saldo >= TransParam.monto)
                    {
                        var queryOrigen = (from a in _context.Cuenta
                                           where a.Codigo.Trim() == TransParam.CuentaOrigen.Trim()
                                           select a).FirstOrDefault();

                        queryOrigen.Saldo = queryOrigen.Saldo - TransParam.monto;
                        var modificacionCuentaOrigen = _context.Cuenta.Attach(queryOrigen);
                        modificacionCuentaOrigen.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();

                        var queryDestino = (from a in _context.Cuenta
                                            where a.Codigo == TransParam.CuentaDestino
                                            select a).FirstOrDefault();

                        queryDestino.Saldo = queryDestino.Saldo + TransParam.monto;

                        var modificacionCuentaBeneficiario = _context.Cuenta.Attach(queryDestino);
                        modificacionCuentaBeneficiario.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();

                        Transferencias transferencia = new Transferencias();
                        transferencia.Id = secuencia + 1;
                        transferencia.Destino = TransParam.CuentaDestino;
                        transferencia.Origen = TransParam.CuentaOrigen;
                        transferencia.Monto = TransParam.monto;
                        // Concepto Concept = (Concepto)TransParam.Motivo;
                        transferencia.Concepto = motivo;
                        _context.Transferencia.Add(transferencia);
                        _context.SaveChanges();
                    }
                    else
                    {
                        mensaje = "Cuenta origen no posee saldo suficiente";
                    }

                }
                else
                {
                    mensaje = "No existe cuenta destino";
                }
            }
            else
            {
                mensaje = "No existe cuenta origen";
            }

            return await Task.FromResult(mensaje);
        }

        public async Task<IEnumerable<TransferenciaReporteDTOs>> transferenciaReporte(string cuenta)
        {
            var listaTransferencia = await _context.Transferencia.ToListAsync();
            var cuentaDestino = (from i in listaTransferencia
                          where i.Destino == cuenta
                          select new TransferenciaReporteDTOs
                          {
                              Cuenta = i.Destino,
                              Monto = i.Monto,
                              Concepto = i.Concepto.ToString(),
                              TipoTransferencia = "Transferencia Recibida."
                          });

            var cuentaRecibida = (from i in listaTransferencia
                                 where i.Origen == cuenta
                                 select new TransferenciaReporteDTOs
                                 {
                                     Cuenta = i.Origen,
                                     Monto = i.Monto,
                                     Concepto = i.Concepto.ToString(),
                                     TipoTransferencia = "Transferencia Enviada."
                                 });


            var unionCuenta = cuentaDestino.Concat(cuentaRecibida);

            return unionCuenta;
        }
    }
}
