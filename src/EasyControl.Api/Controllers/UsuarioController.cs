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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        // [HttpGet]
        // [AllowAnonymous]
        // public async Task<IActionResult> Obter(string email){
        //     try
        //     {
        //         return Ok(await _usuarioService.Obter(email));
        //     }
        //     catch (Exception ex)
        //     {
        //         return Problem(ex.Message);
        //     }
        // }
        
        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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