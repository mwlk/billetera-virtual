using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WepAppClip.Models;
using WepAppClip.Models.Request;
using WepAppClip.Models.Response;
using WepAppClip.Models.ViewModels;

namespace WepAppClip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                var lista = db.Usuarios.ToList();
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
        public IActionResult Add([FromBody] UsuarioViewModel oModel)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using Billetera_virtualContext db = new Billetera_virtualContext();
                Usuario oUsuario = new Usuario
                {
                    NombreUsuario = oModel.NombreUsuario,
                    Password = oModel.Password,
                    FechaAlta = oModel.FechaAlta,
                    Estado = oModel.Estado,
                    Email = oModel.Email
                };
                db.Usuarios.Add(oUsuario);
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
        public IActionResult Edit([FromBody] UsuarioViewModel oModel)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            try
            {
                using (Billetera_virtualContext db = new Billetera_virtualContext())
                {
                    Usuario oUsuario = db.Usuarios.Find(oModel.IdUsuario);

                    oUsuario.NombreUsuario = oModel.NombreUsuario;
                    oUsuario.Password = oModel.Password;
                    oUsuario.FechaAlta = oModel.FechaAlta;
                    oUsuario.Estado = oModel.Estado;

                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Usuario oUsuario = db.Usuarios.Find(_id);

                    db.Remove(oUsuario);

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
                Usuario oUsuario = db.Usuarios.Find(_id);
                oResponse.Data = oUsuario;
                oResponse.Exito = 1;
                oResponse.Mensaje = "Usuario encontrado";

            }
            catch (Exception e)
            {
                oResponse.Mensaje = e.Message;
            }
            return Ok(oResponse);
        }
        [HttpPost("login")]
        public IActionResult Autentificacion([FromBody] AuthRequest model)
        {
            Response oResponse = new Response
            {
                Exito = 0
            };
            return Ok(model);
        }
    }
    
}
