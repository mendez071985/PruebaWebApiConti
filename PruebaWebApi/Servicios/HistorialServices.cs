using PruebaWebApi.Entities;
using PruebaWebApi.Interfaces;
using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Servicios
{
    public class HistorialServices: IHistorial
    {
        private readonly PostDbContext postDbContext;
        public HistorialServices(PostDbContext postDbContext)
        {
            this.postDbContext = postDbContext;
        }
        public ListaHistorial historialTransferencia(String Cuenta, String TipoTransferencia)
        {
            ListaHistorial retorno = new ListaHistorial();
            if (TipoTransferencia == "R") { 
            var beneficiario = (from pd in postDbContext.SolicitudTransferencias
                             where pd.CuentaBeneficiario == Cuenta
                             select new HistorialTransferencia()
                             {
                                 CuentaBeneficiario = pd.CuentaBeneficiario ,
                                 NombreBeneficiario = pd.NombreBeneficiario,
                                 Monto = pd.Monto,
                                 Motivo = pd.Motivo,
                                 Fecha = pd.Fecha
                             }).ToList();
            retorno.ListaHistorico = beneficiario;
            

            }else
            {
                var remitente = (from pd in postDbContext.SolicitudTransferencias
                                 where pd.CuentaRemitente == Cuenta
                                 select new HistorialTransferencia()
                                 {
                                     CuentaRemitente = pd.CuentaRemitente,
                                     NombreRemitente = pd.NombreRemitente,
                                     Monto = pd.Monto,
                                     Motivo = pd.Motivo,
                                     Fecha = pd.Fecha
                                 }).ToList();
                retorno.ListaHistorico = remitente;

            }
            return retorno;
        }

    }
}
