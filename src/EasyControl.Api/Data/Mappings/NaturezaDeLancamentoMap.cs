using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyControl.Api.Data.Mappings
{
    public class NaturezaDeLancamentoMap : IEntityTypeConfiguration<NaturezaDeLancamento>
    {
        public void Configure(EntityTypeBuilder<NaturezaDeLancamento> builder)
        {
           builder.ToTable("NaturezaDeLancamento").HasKey(p => p.Id);
           builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(fk => fk.IdUsuario);
           builder.Property(p => p.Descricao).HasColumnType("VARCHAR(500)").IsRequired();
           builder.Property(p => p.Observacao).HasColumnType("VARCHAR(500)");
           builder.Property(p => p.DataCadastro).HasColumnType("datetime2").IsRequired();
           builder.Property(p => p.DataInativacao).HasColumnType("datetime2");
        }
    }
}