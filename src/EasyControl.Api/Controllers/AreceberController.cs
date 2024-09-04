using EasyControl.Api.Contract.Areceber;
using EasyControl.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    [ApiController]
    [Route("titulos-areceber")]
    public class AreceberController : BaseController
    {
        private readonly IService<AreceberRequestContract, AreceberResponseContract, long> _areceberService;
        public AreceberController(IService<AreceberRequestContract, AreceberResponseContract, long> AreceberService)
        {
            _areceberService = AreceberService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(AreceberRequestContract contract){
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Created("",await _areceberService.Adicionar(contract, idUsuario));
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
                return Ok(await _areceberService.Obter(idUsuario));
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
                return Ok(await _areceberService.Obter(id, idUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long id, AreceberRequestContract contract){
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Atualizar(id, contract, idUsuario));
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
                await _areceberService.Inativar(id, idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}