using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioLoginResponseContract> Adicionar(UsuarioRequestContract entidade, long idUsuario)
        {
            await _usuarioRepository.Adicionar();
        }

        public Task<UsuarioLoginResponseContract> Atualizar(long id, UsuarioRequestContract entidade, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest)
        {
            throw new NotImplementedException();
        }

        public Task Inativar(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioLoginResponseContract>> Obter(long idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioLoginResponseContract> Obter(long id, long idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}