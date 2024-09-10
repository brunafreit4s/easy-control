using EasyControl.Api.Contract.Apagar;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    public interface IApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        Task<IEnumerable<ApagarRequestContract>> ObterNaturezasVinculadas(long idNaturezaDeLancamento);
    }
}