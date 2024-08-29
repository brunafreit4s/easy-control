using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario, long>
    {
        Task<Usuario> Obter(string email);
    }
}