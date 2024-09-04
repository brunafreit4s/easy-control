using EasyControl.Api.Contract.NaturezaDeLancamento;
using EasyControl.Api.Domain.Services.Interfaces;
using EasyControl.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    [ApiController]
    [Route("naturezas-de-lancamento")]
    public class NaturezaDeLancamentoController : BaseController
    {
        private readonly IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long> _naturezaDeLancamentoServiceaturezaDeLancamentoService;
        public NaturezaDeLancamentoController(IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long> NaturezaDeLancamentoService)
        {
            _naturezaDeLancamentoServiceaturezaDeLancamentoService = NaturezaDeLancamentoService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(NaturezaDeLancamentoRequestContract contract){
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Created("",await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Adicionar(contract, _idUsuario));
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
                return Ok(await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Obter(_idUsuario));
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
                return Ok(await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Obter(id, _idUsuario));
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
        public async Task<IActionResult> Atualizar(long id, NaturezaDeLancamentoRequestContract contract){
            try
            {
                _idUsuario = ObterIdUsuarioLogado();
                return Ok(await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Atualizar(id, contract, _idUsuario));
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
                await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Inativar(id, _idUsuario);
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