using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyControl.Api.Domain.Repository.Interfaces
{
    // T: Tipo 
    // I: Identificador
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> Obter(); 
        Task<T?> Obter(I id); 
        Task<T> Adicionar(T endidade);
        Task<T> Atualizar(T endidade);
        Task Deletar(T endidade);
    }
}