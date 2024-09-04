using EasyControl.Api.Data;
using EasyControl.Api.Domain.Models;
using EasyControl.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyControl.Api.Domain.Repository.Classes
{
    public class AreceberRepository : IAreceberRepository
    {
        private readonly ApplicationContext _contexto;

        public AreceberRepository(ApplicationContext context){
            _contexto = context;
        }

        public async Task<Areceber> Adicionar(Areceber entidade)
        {
            await _contexto.Areceber.AddAsync(entidade);
            await _contexto.SaveChangesAsync();
            return entidade;
        }

        public async Task<Areceber> Atualizar(Areceber entidade)
        {
            Areceber entidadeBanco = await _contexto.Areceber                
                .Where(a => a.Id == entidade.Id)
                .FirstOrDefaultAsync();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Areceber>(entidadeBanco);

            await _contexto.SaveChangesAsync();
            
            return entidadeBanco;
        }

        public async Task Deletar(Areceber entidade)
        {
            // Deleção lógico, só altera a data de inativaão
            entidade.DataInativacao = DateTime.Now;
            await Atualizar(entidade);
        }

        public async Task<IEnumerable<Areceber>> Obter()
        {
            return await _contexto.Areceber.AsNoTracking()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Areceber?> Obter(long id)
        {
            return await _contexto.Areceber.AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Areceber>> ObterPeloIdUsuario(long idUsuario)
        {
            return await _contexto.Areceber.AsNoTracking()
                .Where(a => a.IdUsuario == idUsuario)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }
    }
}