using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WepAppClip.Models;
using WepAppClip.Models.Request;
using WepAppClip.Models.Response;
using WepAppClip.Tools;

namespace WepAppClip.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppSettings _appsettings;

        public UsuarioService(IOptions<AppSettings> appSettings)
        {
            _appsettings = appSettings.Value;
        }
        public LoginResponse Auth(AuthRequest request)
        {
            LoginResponse response = new LoginResponse();

            using (var db = new Billetera_virtualContext()) 
            {
                string encryptPass = Encrypter.GetSHA256(request.Password);

                var usuario = db.Clientes.Where(d => d.Email == request.Email
                                                && d.Password == encryptPass).FirstOrDefault();

                if (usuario == null)
                {
                    return null;
                }

                response.Email = usuario.Email;
                response.Id = usuario.IdCliente;
                response.Token = GetToken(usuario);
            }

            return response;
        }

        private string GetToken(Cliente usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appsettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdCliente.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
