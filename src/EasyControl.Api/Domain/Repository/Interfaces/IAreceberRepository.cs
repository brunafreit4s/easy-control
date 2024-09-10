using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    public interface IAreceberRepository : IRepository<Areceber, long>
    {
        Task<IEnumerable<Areceber>> ObterPeloIdUsuario(long idUsuario);
        Task<IEnumerable<Areceber>> ObterNaturezasVinculadas(long IdNaturezaDeLancamento);
    }
}