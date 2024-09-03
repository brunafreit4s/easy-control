using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected long ObterIdUsuarioLogado(){
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            long.TryParse(id, out long idUsuario);

            return idUsuario;
        }
    }
}