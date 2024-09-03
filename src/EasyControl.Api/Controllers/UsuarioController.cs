using System.Security.Authentication;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(UsuarioLoginRequestContract contract){
            try
            {
                return Ok(await _usuarioService.Autenticar(contract));
            }
            catch(AuthenticationException ex){
                return Unauthorized(new {StatusCode = 402, message = ex.Message});
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(UsuarioRequestContract contract){
            try
            {
                return Created("",await _usuarioService.Adicionar(contract, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Obter(){
            try
            {
                return Ok(await _usuarioService.Obter(0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long id){
            try
            {
                return Ok(await _usuarioService.Obter(id, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long id, UsuarioRequestContract contract){
            try
            {
                return Ok(await _usuarioService.Atualizar(id, contract, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(long id){
            try
            {
                await _usuarioService.Inativar(id, 0);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}