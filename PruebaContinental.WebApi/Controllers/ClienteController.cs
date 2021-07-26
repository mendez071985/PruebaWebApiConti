using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContinental.Core.DTOs;
using PruebaContinental.Core.Entities;
using PruebaContinental.Core.Interfaces;
using PruebaContinental.WebApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaContinental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteSerivice _iClienteSerivice;
        private readonly IMapper _mapper;
        public ClienteController(IClienteSerivice iClienteSerivice, IMapper mapper)
        {
            _iClienteSerivice = iClienteSerivice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _iClienteSerivice.GetClientes();
            var clienteDtos = _mapper.Map<IEnumerable<ClienteDTOs>>(clientes);
            var response = new ApiResponse<IEnumerable<ClienteDTOs>>(clienteDtos);
            return Ok(response);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetCliente(string codigo)
        {
            var cliente = await _iClienteSerivice.GetCliente(codigo);
            var clienteDto = _mapper.Map<ClienteDTOs>(cliente);
            var response = new ApiResponse<ClienteDTOs>(clienteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ClientePos(ClienteDTOs clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteDtos = _mapper.Map<Cliente>(clienteDTO);
            await _iClienteSerivice.InsertPost(clienteDtos);

            clienteDTO = _mapper.Map<ClienteDTOs>(clienteDtos);

            var response = new ApiResponse<ClienteDTOs>(clienteDTO);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ClientePut(double id, ClienteDTOs clienteDTO)
        {
            var clienteDtosPut = _mapper.Map<Cliente>(clienteDTO);
            clienteDtosPut.Id = id;
            var result = await _iClienteSerivice.UpdateCliente(clienteDtosPut);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> ClienteDelete(string codigo)
        {
            //var clienteDtos = _mapper.Map<Cliente>(codigo);
            var result = await _iClienteSerivice.DeleteCliente(codigo);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
