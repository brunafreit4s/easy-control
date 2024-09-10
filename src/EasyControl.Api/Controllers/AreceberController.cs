using EasyControl.Api.Contract.Areceber;
using EasyControl.Api.Domain.Services.Interfaces;
using EasyControl.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    [ApiController]
    [Route("titulos-areceber")]
    public class AreceberController : BaseController
    {
        private readonly IAreceberService _areceberService;
        public AreceberController(IAreceberService AreceberService)
        {
            _areceberService = AreceberService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(AreceberRequestContract contract){
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Created("",await _areceberService.Adicionar(contract, _idUsuario));
            }
            catch (BadRequestException ex){
                return BadRequest(ReturnBadRequest(ex));
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
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Obter(_idUsuario));
            }
            catch(NotFoundException ex){
                return NotFound(ReturnNotFound(ex));
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
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Obter(id, _idUsuario));
            }
            catch(NotFoundException ex){
                return NotFound(ReturnNotFound(ex));
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
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _areceberService.Atualizar(id, contract, _idUsuario));
            }
            catch(NotFoundException ex){
                return NotFound(ReturnNotFound(ex));
            }
            catch (BadRequestException ex){
                return BadRequest(ReturnBadRequest(ex));
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
                _idUsuario = ObterIdUsuarioLogado();
                await _areceberService.Inativar(id, _idUsuario);
                return NoContent();
            }
            catch(NotFoundException ex){
                return NotFound(ReturnNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("naturezas/vinculadas")]
        [Authorize]
        public async Task<IActionResult> ObterNaturezasVinculadas(long idNaturezaDeLancamento){
            try
            {
                return Ok(await _areceberService.ObterNaturezasVinculadas(idNaturezaDeLancamento));
            }
            catch(NotFoundException ex){
                return NotFound(ReturnNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}