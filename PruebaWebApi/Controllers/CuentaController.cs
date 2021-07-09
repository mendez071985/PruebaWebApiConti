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
    public class CuentaController : ControllerBase
    {
        private readonly ICuenta _iCuenta;
        public CuentaController(ICuenta icuenta)
        {
            this._iCuenta = icuenta;
        }
        /// <summary>
        /// Para verificar el estado de la cuenta
        /// </summary>
        /// <param name="Cuenta"></param>
        /// <returns></returns>
        [HttpGet(("{Cuenta}"))]
        public IActionResult Historial(String Cuenta)
        {

            var name = _iCuenta.estadoCuenta(Cuenta);
            return Ok(name);
        }
        /// <summary>
        /// Se utiliza para ingresar cuenta
        /// </summary>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Cuenta([FromBody] Cuentas cuentas)
        {

            var name = _iCuenta.registrar(cuentas);
            return Ok(name);
        }
        /// <summary>
        /// Realizamos para borrar cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult Cuenta(int id)
        {
            var isDelete = _iCuenta.borrar(id);
            return Ok(isDelete);
        }

        /// <summary>
        /// Realizamos para actualizar en cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut()]
        public IActionResult Cuentas([FromBody] Cuentas cuenta)
        {
            var name = _iCuenta.modificar(cuenta);
            return Ok(name);
        }
    }
}
