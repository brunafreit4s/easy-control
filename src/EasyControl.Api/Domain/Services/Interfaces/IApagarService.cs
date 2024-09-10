using EasyControl.Api.Contract.Apagar;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    public interface IApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        Task<IEnumerable<ApagarRequestContract>> ObterNaturezasVinculadas(long idNaturezaDeLancamento);
        Task<IEnumerable<ApagarRequestContract>> ObterTitulosPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}