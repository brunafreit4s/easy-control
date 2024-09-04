using EasyControl.Api.Contract.Apagar;
using EasyControl.Api.Domain.Services.Interfaces;
using EasyControl.Api.Exceptions;
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
                _idUsuario = ObterIdUsuarioLogado();
                return Created("",await _apagarService.Adicionar(contract, _idUsuario));
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
                return Ok(await _apagarService.Obter(_idUsuario));
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
                return Ok(await _apagarService.Obter(id, _idUsuario));
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
        public async Task<IActionResult> Atualizar(long id, ApagarRequestContract contract){
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _apagarService.Atualizar(id, contract, _idUsuario));
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
                await _apagarService.Inativar(id, _idUsuario);
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
    }
}