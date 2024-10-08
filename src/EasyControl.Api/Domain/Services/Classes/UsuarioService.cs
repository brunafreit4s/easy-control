using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using EasyControl.Api.Domain.Services.Interfaces;
using EasyControl.Api.Exceptions;

namespace EasyControl.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, TokenService tokenService){
            _usuarioRepository = usuarioRepository;            
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UsuarioLoginResponseContract> Autenticar(UsuarioLoginRequestContract usuarioLoginRequest)
        {
            var usuario = await Obter(usuarioLoginRequest.Email);
            var hashSenha = GerarHashSenha(usuarioLoginRequest.Senha);

            if(usuario is null || usuario.Senha != hashSenha) {
                throw new AuthenticationException("Usuário ou Senha inválido.");
            }

            return new UsuarioLoginResponseContract{
                Id = usuario.Id,
                Email = usuario.Email,
                Token = _tokenService.ObterToken(_mapper.Map<Usuario>(usuario)),
            };
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
            _ = await Obter(id) ?? throw new NotFoundException("Usuário não encontrado para atualização!");

            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Id = id;
            usuario.Senha = GerarHashSenha(entidade.Senha);
            usuario = await _usuarioRepository.Atualizar(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }        

        public async Task Inativar(long id, long idUsuario)
        {
            var usuario = await _usuarioRepository.Obter(id) ?? throw new NotFoundException("Usuário não encontrado para inativação!");
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