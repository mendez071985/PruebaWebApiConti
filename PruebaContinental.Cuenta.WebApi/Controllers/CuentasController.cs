using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaContinental.Cuenta.Core.DTOs;
using PruebaContinental.Cuenta.Core.Entities;
using PruebaContinental.Cuenta.Core.Interfaces;
using PruebaContinental.Cuenta.WebApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.Cuenta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaServices _iCuentaServices;
        private readonly IMapper _mapper;
        public CuentasController(ICuentaServices iCuentaServices, IMapper mapper)
        {
            _iCuentaServices = iCuentaServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Cuentas()
        {
            var cuentas = await _iCuentaServices.Cuentas();
            var cuentasDtos = _mapper.Map<IEnumerable<CuentasDto>>(cuentas);
            var response = new ApiResponsesCuentas<IEnumerable<CuentasDto>>(cuentasDtos);
            return Ok(response);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Cuenta(string codigo)
        {
            var cuenta = await _iCuentaServices.Cuenta(codigo);
            var cuentaDto = _mapper.Map<CuentasDto>(cuenta);
            var response = new ApiResponsesCuentas<CuentasDto>(cuentaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ClienteInsertar(CuentasDto cuentaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cuentasDtos = _mapper.Map<Cuentas>(cuentaDTO);
            await _iCuentaServices.InsCuenta(cuentasDtos);

            cuentaDTO = _mapper.Map<CuentasDto>(cuentasDtos);

            var response = new ApiResponsesCuentas<CuentasDto>(cuentaDTO);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ClientePut(double id, CuentasDto cuentaDTO)
        {
            var cuentaDtosPut = _mapper.Map<Cuentas>(cuentaDTO);
            cuentaDtosPut.Id = id;
            var result = await _iCuentaServices.UpdCuenta(cuentaDtosPut);
            var response = new ApiResponsesCuentas<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> CuentaDelete(string codigo)
        {
            //var clienteDtos = _mapper.Map<Cliente>(codigo);
            var result = await _iCuentaServices.DeleteCuenta(codigo);
            var response = new ApiResponsesCuentas<bool>(result);
            return Ok(response);
        }

    }
}
