using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaContinental.Transferencia.Core.DTOs;
using PruebaContinental.Transferencia.Core.Interfaces;
using PruebaContinental.Transferencia.WebApi.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Transferencia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciasController : ControllerBase
    {
        private readonly ITransferenciaServices _iTransferenciaServices;
        public TransferenciasController(ITransferenciaServices iTransferenciaServices)
        {
            _iTransferenciaServices = iTransferenciaServices;
        }

        [HttpPost]
        public async Task<IActionResult> TransferenciaPos(TransParametrosDTOs TransParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = await _iTransferenciaServices.transferencia(TransParam);
            var response = new ApiResponseTransferencia<string>(resultado);
            return Ok(response);
        }

    }
}
