using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    public interface IApagarRepository : IRepository<Apagar, long>
    {
        Task<IEnumerable<Apagar>> ObterPeloIdUsuario(long idUsuario);
        Task<IEnumerable<Apagar>> ObterNaturezasVinculadas(long IdNaturezaDeLancamento);
        Task<IEnumerable<Apagar>> ObterTitulosPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}