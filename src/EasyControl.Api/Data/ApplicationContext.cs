using EasyControl.Api.Data.Mappings;
using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyControl.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario {get; set;}
        public DbSet<NaturezaDeLancamento> NaturezaDeLancamento {get; set;}
        public DbSet<Apagar> Apagar {get; set;}
        public DbSet<Areceber> Areceber {get; set;}
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NaturezaDeLancamentoMap());
            modelBuilder.ApplyConfiguration(new ApagarMap());
            modelBuilder.ApplyConfiguration(new AreceberMap());            
        }
    }
}