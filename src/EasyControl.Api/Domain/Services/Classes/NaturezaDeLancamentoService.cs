using AutoMapper;
using EasyControl.Api.Contract.NaturezaDeLancamento;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;
using EasyControl.Api.Exceptions;

namespace EasyControl.Api.Domain.Services.Classes
{
    //public class NaturezaDeLancamentoService : IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long>
    public class NaturezaDeLancamentoService : INaturezaDeLancamentoService
    {
        private readonly INaturezaDeLancamentoRepository _naturezaDeLancamentoRepository;
        private readonly IMapper _mapper;

        public NaturezaDeLancamentoService(INaturezaDeLancamentoRepository naturezaDeLancamentoRepository, IMapper mapper){
            _naturezaDeLancamentoRepository = naturezaDeLancamentoRepository;
            _mapper = mapper;
        }

        public async Task<NaturezaDeLancamentoResponseContract> Adicionar(NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {
            var natureza = _mapper.Map<NaturezaDeLancamento>(entidade);

            natureza.DataCadastro = DateTime.Now;
            natureza.IdUsuario = idUsuario;
            natureza = await _naturezaDeLancamentoRepository.Adicionar(natureza);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(natureza);
        }

        public async Task<NaturezaDeLancamentoResponseContract> Atualizar(long id, NaturezaDeLancamentoRequestContract entidade, long idUsuario)
        {        
            NaturezaDeLancamento natureza = await ObterVinculoUsuario(id, idUsuario);

            natureza.Descricao = entidade.Descricao;
            natureza.Observacao = entidade.Observacao;
            natureza = await _naturezaDeLancamentoRepository.Atualizar(natureza);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(natureza);
        }

        public async Task Inativar(long id, long idUsuario)
        {
            NaturezaDeLancamento natureza = await ObterVinculoUsuario(id, idUsuario);
            await _naturezaDeLancamentoRepository.Deletar(natureza);
        }

        public async Task<IEnumerable<NaturezaDeLancamentoResponseContract>> Obter(long idUsuario)
        {
            var naturezasDeLancamento = await _naturezaDeLancamentoRepository.ObterPeloIdUsuario(idUsuario);
            return naturezasDeLancamento.Select(n => _mapper.Map<NaturezaDeLancamentoResponseContract>(n));
        }

        public async Task<NaturezaDeLancamentoResponseContract> Obter(long id, long idUsuario)
        {
            NaturezaDeLancamento natureza = await ObterVinculoUsuario(id, idUsuario);
             return _mapper.Map<NaturezaDeLancamentoResponseContract>(natureza);
        }

        public async Task<IEnumerable<NaturezaDeLancamentoResponseContract>> ObterAtivos(bool ativos)
        {
            var naturezasDeLancamento = await _naturezaDeLancamentoRepository.ObterAtivos(ativos);
            return naturezasDeLancamento.Select(n => _mapper.Map<NaturezaDeLancamentoResponseContract>(n));
        }

        private async Task<NaturezaDeLancamento> ObterVinculoUsuario(long id, long idUsuario){
            var naturezaDeLancamento = await _naturezaDeLancamentoRepository.Obter(id);
            if (naturezaDeLancamento is null || naturezaDeLancamento.IdUsuario != idUsuario){
                throw new NotFoundException($"Não foi encontrada nenhuma natureza de lançamento pelo id {id}");
            }

            return naturezaDeLancamento;
        }
    }
}