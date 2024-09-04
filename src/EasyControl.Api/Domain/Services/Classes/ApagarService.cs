using AutoMapper;
using EasyControl.Api.Contract.Apagar;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;
using EasyControl.Api.Exceptions;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class ApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        private readonly IApagarRepository _apagarRepository;
        private readonly IMapper _mapper;

        public ApagarService(IApagarRepository ApagarRepository, IMapper mapper){
            _apagarRepository = ApagarRepository;
            _mapper = mapper;
        }

        public async Task<ApagarResponseContract> Adicionar(ApagarRequestContract entidade, long idUsuario)
        {
            Validar(entidade);

            var apagar = _mapper.Map<Apagar>(entidade);

            apagar.DataCadastro = DateTime.Now;
            apagar.IdUsuario = idUsuario;
            apagar = await _apagarRepository.Adicionar(apagar);

            return _mapper.Map<ApagarResponseContract>(apagar);
        }

        public async Task<ApagarResponseContract> Atualizar(long id, ApagarRequestContract entidade, long idUsuario)
        {        
            Validar(entidade);
            
            Apagar apagar = await ObterVinculoUsuario(id, idUsuario);

            var contrato = _mapper.Map<Apagar>(entidade);
            contrato.Id = apagar.Id;
            contrato.IdUsuario = apagar.IdUsuario;
            contrato.DataCadastro = apagar.DataCadastro;

            // apagar.Descricao = entidade.Descricao;
            // apagar.Observacao = entidade.Observacao;
            // apagar.ValorOriginal = entidade.ValorOriginal;
            // apagar.ValorPago = entidade.ValorPago;
            // apagar.DataPagamento = entidade.DataPagamento;
            // apagar.DataReferencia = entidade.DataReferencia;
            // apagar.DataVencimento = entidade.DataVencimento;
            // apagar.IdNaturezaDeLancamento = entidade.IdNaturezaDeLancamento;

            contrato = await _apagarRepository.Atualizar(contrato);

            return _mapper.Map<ApagarResponseContract>(contrato);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            Apagar apagar = await ObterVinculoUsuario(id, idUsuario);
            await _apagarRepository.Deletar(apagar);
        }

        public async Task<IEnumerable<ApagarResponseContract>> Obter(long idUsuario)
        {
            var tituloApagar = await _apagarRepository.ObterPeloIdUsuario(idUsuario);
            return tituloApagar.Select(a => _mapper.Map<ApagarResponseContract>(a));
        }

        public async Task<ApagarResponseContract> Obter(long id, long idUsuario)
        {
            Apagar apagar = await ObterVinculoUsuario(id, idUsuario);
             return _mapper.Map<ApagarResponseContract>(apagar);
        }

        private async Task<Apagar> ObterVinculoUsuario(long id, long idUsuario){
            var apagar = await _apagarRepository.Obter(id);
            if (apagar is null || apagar.IdUsuario != idUsuario){
                throw new NotFoundException($"Não foi encontrada nenhuma título a pagar pelo id {id}");
            }

            return apagar;
        }
    
        private void Validar(ApagarRequestContract entidade){
            if(entidade.ValorOriginal < 0 || entidade.ValorPago < 0) { throw new BadRequestException("Os campos de valor original e valor de recebimento, não podem ser negativos!"); }
        }
    }
}