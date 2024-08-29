namespace EasyControl.Api.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface genérica para criação de serviços do tipo CRUD
    /// </summary>
    /// <typeparam name="RQ">Contrato de Request</typeparam>
    /// <typeparam name="RS">Contrato de Response</typeparam>
    /// <typeparam name="I">Tipo do Identificador</typeparam>    
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Obter(I idUsuario);
        Task<RS> Obter(I id, I idUsuario);
        Task<RS> Adicionar(RQ entidade, I idUsuario);
        Task<RS> Atualizar(I id, RQ entidade, I idUsuario);
        Task Inativar(I id, I idUsuario);
    }
}