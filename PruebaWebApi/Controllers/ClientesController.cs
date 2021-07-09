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
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _icliente;
        public ClientesController(ICliente icliente)
        {
            this._icliente = icliente;
        }

        [HttpGet]
        public string Get()
        {
            string value = "";
            return value;
        }
        /// <summary>
        /// registra un cliente
        /// </summary> Realizamos para ingresar cliente
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost()]     
        public IActionResult Clientes([FromBody] Cliente cliente)
        {

            var name = _icliente.registrar(cliente);
            return Ok(name); 
        }
        /// <summary>
        ///Realizamos para borra un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult Clientes(int id)
        {
            var isDelete = _icliente.borrar(id);
            return Ok(isDelete);
        }
        /// <summary>
        /// Utilizamos para actualizar en cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut()]
        public IActionResult Cliente([FromBody] Cliente modificarCliente)
        
        {
            var name = _icliente.modificar(modificarCliente);
            return Ok(name);
        }
    }
}
