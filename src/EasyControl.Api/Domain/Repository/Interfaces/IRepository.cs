namespace EasyControl.Api.Domain.Repository.Interfaces
{
    // T: Tipo 
    // I: Identificador
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> Obter(); 
        Task<T?> Obter(I id); 
        Task<T> Adicionar(T entidade);
        Task<T> Atualizar(T entidade);
        Task Deletar(T entidade);
    }
}