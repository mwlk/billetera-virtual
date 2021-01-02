using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppClip.Models;
using WepAppClip.Models.Response;
using WepAppClip.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepAppClip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        // GET: api/<CuentaController>
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                List<CuentaViewModel> lista = (from c in db.Cuenta
                                               join cl in db.Clientes on c.IdCliente equals cl.IdCliente
                                               join b in db.EntidadBancaria on c.IdEntidadBancaria equals b.IdEntidadBancaria
                                               join tm in db.TipoMoneda on c.IdTipoMoneda equals tm.IdTipoMoneda
                                               select new CuentaViewModel
                                               {
                                                   IdCuenta = c.IdCuenta,
                                                   IdEntidadBancaria = c.IdEntidadBancaria,
                                                   IdCliente = c.IdCliente,
                                                   IdTipoMoneda = c.IdTipoMoneda,
                                                   Cvu = c.Cvu,
                                                   FechaAlta = c.FechaAlta,
                                                   Estado = c.Estado,
                                                   Saldo = c.Saldo,
                                                   TopeDescubierto = c.TopeDescubierto,

                                                   NombreCliente = cl.Apellido + ", " + cl.Nombre,
                                                   NombreBanco = b.Nombre,
                                                   TipoMoneda = tm.Nombre
                                               }).ToList();
                oResponse.Exito = 1;
                oResponse.Data = lista;
                oResponse.Mensaje = "istado de cuentas generado";
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpGet("GetByCliente/{_id}")]
        public IActionResult GetByCliente(int _id)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                List<CuentaViewModel> lista = (from c in db.Cuenta
                                               where c.IdCliente == _id
                                               join cl in db.Clientes on c.IdCliente equals cl.IdCliente
                                               join b in db.EntidadBancaria on c.IdEntidadBancaria equals b.IdEntidadBancaria
                                               join tm in db.TipoMoneda on c.IdTipoMoneda equals tm.IdTipoMoneda
                                               select new CuentaViewModel
                                               {
                                                   IdCuenta = c.IdCuenta,
                                                   IdEntidadBancaria = c.IdEntidadBancaria,
                                                   IdCliente = c.IdCliente,
                                                   IdTipoMoneda = c.IdTipoMoneda,
                                                   Cvu = c.Cvu,
                                                   FechaAlta = c.FechaAlta,
                                                   Estado = c.Estado,
                                                   Saldo = c.Saldo,
                                                   TopeDescubierto = c.TopeDescubierto,

                                                   NombreCliente = cl.Apellido + ", " + cl.Nombre,
                                                   NombreBanco = b.Nombre,
                                                   TipoMoneda = tm.Nombre
                                               }).ToList();
                oResponse.Exito = 1;
                oResponse.Data = lista;
                oResponse.Mensaje = "listado de cuentas del cliente: "+_id+" generados con exito";
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        /*
        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CuentaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        **/
    }
}
