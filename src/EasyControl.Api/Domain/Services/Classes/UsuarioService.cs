using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper){
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponseContract> Adicionar(UsuarioRequestContract entidade, long idUsuario)
        {
            var usuario = _mapper.Map<Usuario>(entidade);

            usuario.Senha = GerarHashSenha(usuario.Senha);
            usuario.DataCadastro = DateTime.Now;
            usuario = await _usuarioRepository.Adicionar(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        private string GerarHashSenha(string senha){
            string hashSenha;

            using(SHA256 sHA256 = SHA256.Create())
            {
                byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
                byte[] bytesHashSenha = sHA256.ComputeHash(bytesSenha);
                hashSenha = BitConverter.ToString(bytesHashSenha).Replace("-","").ToLower();
            }            
            return hashSenha;
        }

        public async Task<UsuarioResponseContract> Atualizar(long id, UsuarioRequestContract entidade, long idUsuario)
        {
            _ = await Obter(id) ?? throw new Exception("Usuário não encontrado para atualização!");

            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Id = id;
            usuario.Senha = GerarHashSenha(entidade.Senha);
            usuario = await _usuarioRepository.Atualizar(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }        

        public async Task Inativar(long id, long idUsuario)
        {
            var usuario = await _usuarioRepository.Obter(id) ?? throw new Exception("Usuário não encontrado para inativação!");
            await _usuarioRepository.Deletar(_mapper.Map<Usuario>(usuario));
        }

        public async Task<IEnumerable<UsuarioResponseContract>> Obter(long idUsuario)
        {
            var usuarios = await _usuarioRepository.Obter();
            return usuarios.Select(usuarios => _mapper.Map<UsuarioResponseContract>(usuarios));
        }

        public async Task<UsuarioResponseContract> Obter(long id, long idUsuario)
        {
            var usuario = await _usuarioRepository.Obter(id);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
        
        public async Task<UsuarioResponseContract> Obter(string email)
        {
            var usuario = await _usuarioRepository.Obter(email);
            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
    }
}