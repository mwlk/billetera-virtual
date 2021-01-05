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
    public class OperacionController : ControllerBase
    {
        // GET: api/<ValuesController>
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
                List<OperacionViewModel> lista = (from o in db.Operacions
                                                  join to in db.TipoOperacions on o.IdTipoOperacion equals to.IdTipoOperacion
                                                  select new OperacionViewModel
                                                  {
                                                      IdOperacion = o.IdOperacion,
                                                      IdTipoOperacion = o.IdTipoOperacion,
                                                      IdCuenta = o.IdCuenta,
                                                      NroOperacion = o.NroOperacion,
                                                      Estado = o.Estado,
                                                      FechaOperacion = o.FechaOperacion,
                                                      HoraOperacion = o.HoraOperacion,
                                                      Monto = o.Monto,
                                                      TipoOperacion = to.Nombre

                                                  }).ToList();

                oResponse.Data = lista;
                oResponse.Mensaje = "Listado de operaciones generados con exito";
                oResponse.Exito = 1;
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost("[action]")]
        public IActionResult AddOperacion([FromBody] OperacionViewModel oModel)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                Operacion oOperacion = new Operacion
                {
                    IdOperacion = oModel.IdOperacion,
                    IdTipoOperacion = oModel.IdTipoOperacion,
                    IdCuenta = oModel.IdCuenta,
                    NroOperacion = oModel.NroOperacion,
                    Estado = oModel.Estado,
                    FechaOperacion = oModel.FechaOperacion,
                    HoraOperacion = oModel.HoraOperacion,
                    Monto = oModel.Monto
                };
                db.Operacions.Add(oOperacion);
                db.SaveChanges();

                oResponse.Data = oOperacion;
                oResponse.Mensaje = "operacion registrada con exito";
                oResponse.Exito = 1;

            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpGet("gettopten/{_idCuenta}")]
        public IActionResult GetTopTen(int _idCuenta)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                List<OperacionViewModel> lista = (from o in db.Operacions
                                                  where o.IdCuenta == _idCuenta
                                                  join to in db.TipoOperacions on o.IdTipoOperacion equals to.IdTipoOperacion
                                                  select new OperacionViewModel
                                                  {
                                                      IdOperacion = o.IdOperacion,
                                                      IdTipoOperacion = o.IdTipoOperacion,
                                                      IdCuenta = o.IdCuenta,
                                                      NroOperacion = o.NroOperacion,
                                                      Estado = o.Estado,
                                                      FechaOperacion = o.FechaOperacion,
                                                      HoraOperacion = o.HoraOperacion,
                                                      Monto = o.Monto,
                                                      TipoOperacion = to.Nombre

                                                  }).Take(10).ToList();

                oResponse.Data = lista;
                oResponse.Mensaje = "Listado de top 10 generados con exito";
                oResponse.Exito = 1;
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }

            return Ok(oResponse);
        }
        /*
                // GET api/<ValuesController>/5
                [HttpGet("{id}")]
                public string Get(int id)
                {
                    return "value";
                }

                // POST api/<ValuesController>
                [HttpPost]
                public void Post([FromBody] string value)
                {
                }

                // PUT api/<ValuesController>/5
                [HttpPut("{id}")]
                public void Put(int id, [FromBody] string value)
                {
                }

                // DELETE api/<ValuesController>/5
                [HttpDelete("{id}")]
                public void Delete(int id)
                {
                }
                */
    }
}
