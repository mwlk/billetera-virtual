using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WepAppClip.Models;
using WepAppClip.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepAppClip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : Controller
    {
        // GET: api/<ProvinciaController>
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
                var listado = db.Provincia.ToList();
                oResponse.Exito = 1;
                oResponse.Mensaje = "Listado de provincias generado";
                oResponse.Data = listado;
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }

            return Ok(oResponse);
        }

        [HttpGet("ById/{_id}")]
        public IActionResult GetLocalidades(int _id)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                List<Localidad> listado = (from p in db.Provincia
                                           where p.IdProvincia == _id
                                           join l in db.Localidads on p.IdProvincia equals l.IdProvincia
                                           select new Localidad
                                           {
                                               IdLocalidad = l.IdLocalidad,
                                               Nombre = l.Nombre,
                                               IdProvincia = l.IdProvincia,
                                               CodigoPostal = l.CodigoPostal
                                           }).ToList();
                    
                
               
                oResponse.Exito = 1;
                oResponse.Mensaje = "Listado de localidades generado";
                oResponse.Data = listado;
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }

            return Ok(oResponse);
        }

        /*
        // GET api/<ProvinciaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProvinciaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProvinciaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //DELETE api/<ProvinciaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
