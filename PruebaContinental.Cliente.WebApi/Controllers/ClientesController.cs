using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaContinental.Cliente.Core.DTOs;
using PruebaContinental.Cliente.Core.Entities;
using PruebaContinental.Cliente.Core.Interfaces;
using PruebaContinental.Cliente.WebApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PruebaContinental.Cliente.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServices _iClienteServices;
        private readonly IMapper _mapper;
        public ClientesController(IClienteServices iClienteSerivice, IMapper mapper)
        {
            _iClienteServices = iClienteSerivice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Clientes()
        {
            var clientes = await _iClienteServices.Clientes();
            var clienteDtos = _mapper.Map<IEnumerable<ClientesDto>>(clientes);
            var response = new ApiResponses<IEnumerable<ClientesDto>>(clienteDtos);
            return Ok(response);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Cliente(string codigo)
        {
            var cliente = await _iClienteServices.Cliente(codigo);
            var clienteDto = _mapper.Map<ClientesDto>(cliente);
            var response = new ApiResponses<ClientesDto>(clienteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ClienteInsertar(ClientesDto clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteDtos = _mapper.Map<Clientes>(clienteDTO);
            await _iClienteServices.InsCliente(clienteDtos);

            clienteDTO = _mapper.Map<ClientesDto>(clienteDtos);

            var response = new ApiResponses<ClientesDto>(clienteDTO);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ClientePut(double id, ClientesDto clienteDTO)
        {
            var clienteDtosPut = _mapper.Map<Clientes>(clienteDTO);
            clienteDtosPut.Id = id;
            var result = await _iClienteServices.UpCliente(clienteDtosPut);
            var response = new ApiResponses<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> ClienteDelete(string codigo)
        {
            //var clienteDtos = _mapper.Map<Cliente>(codigo);
            var result = await _iClienteServices.DelCliente(codigo);
            var response = new ApiResponses<bool>(result);
            return Ok(response);
        }

    }
}
