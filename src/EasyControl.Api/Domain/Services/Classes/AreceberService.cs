using AutoMapper;
using EasyControl.Api.Contract.Areceber;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class AreceberService : IService<AreceberRequestContract, AreceberResponseContract, long>
    {
        private readonly IAreceberRepository _areceberRepository;
        private readonly IMapper _mapper;

        public AreceberService(IAreceberRepository AreceberRepository, IMapper mapper){
            _areceberRepository = AreceberRepository;
            _mapper = mapper;
        }

        public async Task<AreceberResponseContract> Adicionar(AreceberRequestContract entidade, long idUsuario)
        {
            var areceber = _mapper.Map<Areceber>(entidade);

            areceber.DataCadastro = DateTime.Now;
            areceber.IdUsuario = idUsuario;
            areceber = await _areceberRepository.Adicionar(areceber);

            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        public async Task<AreceberResponseContract> Atualizar(long id, AreceberRequestContract entidade, long idUsuario)
        {        
            Areceber areceber = await ObterVinculoUsuario(id, idUsuario);

            var contrato = _mapper.Map<Areceber>(entidade);
            contrato.Id = areceber.Id;
            contrato.IdUsuario = areceber.IdUsuario;
            contrato.DataCadastro = areceber.DataCadastro;

            // areceber.Descricao = entidade.Descricao;
            // areceber.Observacao = entidade.Observacao;
            // areceber.ValorOriginal = entidade.ValorOriginal;
            // areceber.ValorPago = entidade.ValorPago;
            // areceber.DataPagamento = entidade.DataPagamento;
            // areceber.DataReferencia = entidade.DataReferencia;
            // areceber.DataVencimento = entidade.DataVencimento;
            // areceber.IdNaturezaDeLancamento = entidade.IdNaturezaDeLancamento;

            contrato = await _areceberRepository.Atualizar(contrato);

            return _mapper.Map<AreceberResponseContract>(contrato);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            Areceber areceber = await ObterVinculoUsuario(id, idUsuario);
            await _areceberRepository.Deletar(areceber);
        }

        public async Task<IEnumerable<AreceberResponseContract>> Obter(long idUsuario)
        {
            var tituloAreceber = await _areceberRepository.ObterPeloIdUsuario(idUsuario);
            return tituloAreceber.Select(a => _mapper.Map<AreceberResponseContract>(a));
        }

        public async Task<AreceberResponseContract> Obter(long id, long idUsuario)
        {
            Areceber areceber = await ObterVinculoUsuario(id, idUsuario);
             return _mapper.Map<AreceberResponseContract>(areceber);
        }

        private async Task<Areceber> ObterVinculoUsuario(long id, long idUsuario){
            var areceber = await _areceberRepository.Obter(id);
            if (areceber is null || areceber.IdUsuario != idUsuario){
                throw new Exception($"Não foi encontrada nenhuma título a pagar pelo id {id}");
            }

            return areceber;
        }
    }
}