using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    public interface INaturezaDeLancamentoRepository : IRepository<NaturezaDeLancamento, long>
    {
        Task<IEnumerable<NaturezaDeLancamento>> ObterPeloIdUsuario(long idUsuario);
        Task<IEnumerable<NaturezaDeLancamento>> ObterAtivos(bool ativos);
    }
}