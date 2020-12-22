using WepAppClip.Models.Request;
using WepAppClip.Models.Response;

namespace WepAppClip.Services
{
    public interface IUsuarioService
    {
        LoginResponse Auth(AuthRequest request);
    }
}
