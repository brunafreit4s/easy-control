using EasyControl.Api.Contract.Areceber;

namespace EasyControl.Api.Domain.Services.Interfaces
{
    public interface IAreceberService : IService<AreceberRequestContract, AreceberResponseContract, long>
    {
        Task<IEnumerable<AreceberRequestContract>> ObterNaturezasVinculadas(long idNaturezaDeLancamento);
    }
}