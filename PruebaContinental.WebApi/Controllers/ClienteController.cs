using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaContinental.Core.DTOs;
using PruebaContinental.Core.Entities;
using PruebaContinental.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace PruebaContinental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _iClienteRepository;
        public ClienteController(IClienteRepository iClienteRepository)
        {
            _iClienteRepository = iClienteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            var clientes = _iClienteRepository.GetClientes();
            //var clientesDTOs = clientes.Select (x => new ClienteDTOs
            //{
            //    Id = x.ID
            //});
            return await clientes;
        }
        [HttpPost]
        public async Task<IActionResult> Cliente(Cliente cliente)
        {
             await _iClienteRepository.InsertPost(cliente);
            return Ok(cliente);
        }

    }
}
