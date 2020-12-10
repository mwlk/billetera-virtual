using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WepAppClip.Models;
using WepAppClip.Models.Response;
using WepAppClip.Models.ViewModels;

namespace WepAppClip.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
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
                var lista = db.Clientes.ToList();
                oResponse.Exito = 1;
                oResponse.Data = lista;
                oResponse.Mensaje = "Operacion Exitosa";
            }
            catch (Exception e)
            {
                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromBody] ClienteViewModel oModel)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                Cliente oCliente = new Cliente
                {
                    Nombre = oModel.Nombre,
                    Apellido = oModel.Apellido,
                    Estado = oModel.Estado,
                    IdDireccion = oModel.IdDireccion,
                    NroTelefono = oModel.NroTelefono,
                    NroDni = oModel.NroDni,
                    FrontalDni = oModel.FrontalDni,
                    TraseraDni = oModel.TraseraDni,
                    Email = oModel.Email,
                    IdUsuario = oModel.IdUsuario
    };
                db.Clientes.Add(oCliente);
                db.SaveChanges();

                //codigo de exito = 1, si da error es = 0
                oResponse.Exito = 1;
                oResponse.Mensaje = "Registro Insertado";
            }
            catch (Exception e)
            {
                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpPut("[action]")]
        public IActionResult Edit([FromBody] ClienteViewModel oModel)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using (Billetera_virtualContext db = new Billetera_virtualContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.IdCliente);

                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Apellido = oModel.Apellido;
                    oCliente.Estado = oModel.Estado;
                    oCliente.IdDireccion = oModel.IdDireccion;
                    oCliente.NroTelefono = oModel.NroTelefono;
                    oCliente.NroDni = oModel.NroDni;
                    oCliente.FrontalDni = oModel.FrontalDni;
                    oCliente.TraseraDni = oModel.TraseraDni;
                    oCliente.Email = oModel.Email;
                    oCliente.IdUsuario = oModel.IdUsuario;

                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    //codigo de exito = 1, si da error es = 0
                    oResponse.Exito = 1;
                    oResponse.Mensaje = "Registro Editado con Exito";
                };
            }
            catch (Exception e)
            {
                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpDelete("{_id}")]
        public IActionResult Delete(int _id)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using (Billetera_virtualContext db = new Billetera_virtualContext())
                {
                   Cliente oCliente = db.Clientes.Find(_id);

                    db.Remove(oCliente);

                    db.SaveChanges();

                    //codigo de exito = 1, si da error es = 0
                    oResponse.Exito = 1;
                    oResponse.Mensaje = "Registro Eliminado con Exito";
                };
            }
            catch (Exception e)
            {
                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpGet("ById/{_id}")]
        public IActionResult GetById(int _id)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                Cliente oCliente = db.Clientes.Find(_id);
                oResponse.Data = oCliente;
                oResponse.Exito = 1;
                oResponse.Mensaje = "Cliente encontrado";

            }
            catch (Exception e)
            {
                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }
    }
}
