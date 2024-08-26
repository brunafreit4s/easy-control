using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyControl.Api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
           builder.ToTable("Usuario").HasKey(p => p.Id);
           builder.Property(p => p.Email).HasColumnType("VARCHAR(500)").IsRequired();
           builder.Property(p => p.Senha).HasColumnType("VARCHAR(500)").IsRequired();
           builder.Property(p => p.DataCadastro).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.DataInativacao).HasColumnType("datetime2");
        }
    }
}