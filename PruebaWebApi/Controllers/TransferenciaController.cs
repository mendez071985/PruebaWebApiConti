using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaWebApi.Interfaces;
using PruebaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferencia _iTransferencia;
        private readonly IHistorial _iHistorial;

        public TransferenciaController(ITransferencia iTransferencia, IHistorial iHistorial)
        {
            this._iTransferencia = iTransferencia;
            this._iHistorial = iHistorial;

        }
        /// <summary>
        /// Recurso para realizar transferencia
        /// </summary> 
        /// <param name="solicTransfe"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Transferencia([FromBody] SolicitudTransferencia solicTransfe)
        {

            var name = _iTransferencia.transferencia(solicTransfe);
            return Ok(name);
        }

        /// <summary>
        /// Usamos para tener el historial de la cuenta y si es tipo beneficiario o remitente
        /// </summary>
        /// <param name="Cuenta"></param>
        /// <param name="TipoTransferencia"></param>
        /// <returns></returns>
        [HttpGet(("{Cuenta}/{TipoTransferencia}"))]
        public IActionResult Historial(String Cuenta, String TipoTransferencia)
        {

            var name = _iHistorial.historialTransferencia(Cuenta, TipoTransferencia);
            return Ok(name);
        }
    }
}
