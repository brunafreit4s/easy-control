using EasyControl.Api.Contract.NaturezaDeLancamento;
using EasyControl.Api.Domain.Services.Interfaces;
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
                long idUsuario = ObterIdUsuarioLogado();
                return Created("",await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Adicionar(contract, idUsuario));
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
                return Ok(await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Obter(idUsuario));
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
                return Ok(await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Obter(id, idUsuario));
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
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Atualizar(id, contract, idUsuario));
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
                await _naturezaDeLancamentoServiceaturezaDeLancamentoService.Inativar(id, idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}