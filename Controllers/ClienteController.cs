using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WepAppClip.Models;
using WepAppClip.Models.Request;
using WepAppClip.Models.Response;
using WepAppClip.Models.ViewModels;
using WepAppClip.Services;

namespace WepAppClip.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public ClienteController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

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
                oResponse.Mensaje = "Listado De Total de Clientes Exitoso";
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
                    Password = oModel.Password
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
                    oCliente.Password = oModel.Password;

                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResponse.Exito = 1;

                }
                //codigo de exito = 1, si da error es = 0
                oResponse.Exito = 1;
                oResponse.Mensaje = "Registro Actualizado";
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

        [HttpGet("[action]")]
        public IActionResult GetListModels()
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                List<ClienteViewModel> lista = (from c in db.Clientes
                                                join d in db.Direccions on c.IdDireccion equals d.IdDireccion
                                                join l in db.Localidads on d.IdLocalidad equals l.IdLocalidad
                                                join p in db.Provincia on l.IdProvincia equals p.IdProvincia
                                                select new ClienteViewModel
                                                {
                                                    IdCliente = c.IdCliente,
                                                    Nombre = c.Nombre,
                                                    Apellido = c.Apellido,
                                                    //Estado = c.Estado,
                                                    NroTelefono = c.NroTelefono,
                                                    NroDni = c.NroDni,
                                                    //FrontalDni = c.FrontalDni,
                                                    //TraseraDni=c.TraseraDni,
                                                    Email = c.Email,
                                                    NomDireccion = d.Calle,
                                                    NomLocalidad = l.Nombre,
                                                    NomProvincia = p.Nombre
                                                }).ToList();

                oResponse.Data = lista;
                oResponse.Mensaje = "View Model generado con exito";
            }
            catch (Exception e)
            {

                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Response response = new Response();
            var usuarioResponse = _usuarioService.Auth(model);

            if (usuarioResponse == null)
            {
                response.Exito = 0;
                response.Mensaje = "Usuario o Password Incorrectos";
                return BadRequest(response);
            }
            response.Exito = 1;
            response.Data = usuarioResponse;
            response.Mensaje = "Usuario Encontrado con Exito";
            return Ok(response);
        }
    }
}

