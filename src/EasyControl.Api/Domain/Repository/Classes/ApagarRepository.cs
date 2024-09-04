using EasyControl.Api.Data;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyControl.Api.Domain.Repository.Classes
{
    public class ApagarRepository : IApagarRepository
    {
        private readonly ApplicationContext _contexto;

        public ApagarRepository(ApplicationContext context){
            _contexto = context;
        }

        public async Task<Apagar> Adicionar(Apagar entidade)
        {
            await _contexto.Apagar.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
            return entidade;
        }

        public async Task<Apagar> Atualizar(Apagar entidade)
        {
            Apagar entidadeBanco = await _contexto.Apagar                
                .Where(a => a.Id == entidade.Id)
                .FirstOrDefaultAsync();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Apagar>(entidadeBanco);

            await _contexto.SaveChangesAsync();
            
            return entidadeBanco;
        }

        public async Task Deletar(Apagar entidade)
        {
            // Deleção lógico, só altera a data de inativaão
            entidade.DataInativacao = DateTime.Now;
            await Atualizar(entidade);
        }

        public async Task<IEnumerable<Apagar>> Obter()
        {
            return await _contexto.Apagar.AsNoTracking()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Apagar?> Obter(long id)
        {
            return await _contexto.Apagar.AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Apagar>> ObterPeloIdUsuario(long idUsuario)
        {
            return await _contexto.Apagar.AsNoTracking()
                .Where(a => a.IdUsuario == idUsuario)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }
    }
}