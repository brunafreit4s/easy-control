using System.Security.Claims;
using EasyControl.Api.Contract;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected long _idUsuario;

        protected long ObterIdUsuarioLogado(){
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            long.TryParse(id, out long idUsuario);

            return idUsuario;
        }

        protected ErrorContract ReturnBadRequest(Exception ex){
            return new  ErrorContract {
                    Status = 400,
                    Title = "Bad Request",
                    Message = ex.Message,
                    DateTime = DateTime.Now           
                };
        }

        protected ErrorContract ReturnNotFound(Exception ex){
            return new  ErrorContract {
                    Status = 404,
                    Title = "Not Found",
                    Message = ex.Message,
                    DateTime = DateTime.Now           
                };
        }

        protected ErrorContract ReturnUnauthorized(Exception ex){
            return new  ErrorContract {
                    Status = 401,
                    Title = "Unauthorized",
                    Message = ex.Message,
                    DateTime = DateTime.Now           
                };
        }
    }
}