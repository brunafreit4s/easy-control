using EasyControl.Api.Contract.NaturezaDeLancamento;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    public interface INaturezaDeLancamentoService : IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long>
    {
        Task<IEnumerable<NaturezaDeLancamentoResponseContract>> ObterAtivos(bool ativos);
    }
}