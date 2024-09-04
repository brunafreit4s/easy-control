using EasyControl.Api.Contract.Apagar;
using EasyControl.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    [ApiController]
    [Route("titulos-apagar")]
    public class ApagarController : BaseController
    {
        private readonly IService<ApagarRequestContract, ApagarResponseContract, long> _apagarService;
        public ApagarController(IService<ApagarRequestContract, ApagarResponseContract, long> ApagarService)
        {
            _apagarService = ApagarService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(ApagarRequestContract contract){
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Created("",await _apagarService.Adicionar(contract, idUsuario));
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
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Obter(idUsuario));
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
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Obter(id, idUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long id, ApagarRequestContract contract){
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Atualizar(id, contract, idUsuario));
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
                long idUsuario = ObterIdUsuarioLogado();
                await _apagarService.Inativar(id, idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}