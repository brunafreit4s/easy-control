using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyControl.Api.Data.Mappings
{
    public class ApagarMap : IEntityTypeConfiguration<Apagar>
    {
        public void Configure(EntityTypeBuilder<Apagar> builder)
        {
           builder.ToTable("TituloApagar").HasKey(p => p.Id);
           builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(fk => fk.IdUsuario).OnDelete(DeleteBehavior.Restrict);;
           builder.HasOne(p => p.NaturezaDeLancamento).WithMany().HasForeignKey(fk => fk.IdNaturezaDeLancamento);
           builder.Property(p => p.Descricao).HasColumnType("VARCHAR(500)").IsRequired();
           builder.Property(p => p.Observacao).HasColumnType("VARCHAR(500)");
           builder.Property(p => p.ValorOriginal).HasColumnType("double precision").IsRequired();
           builder.Property(p => p.ValorPago).HasColumnType("double precision").IsRequired();
           builder.Property(p => p.DataCadastro).HasColumnType("datetime2").IsRequired();
           builder.Property(p => p.DataPagamento).HasColumnType("datetime2");
           builder.Property(p => p.DataReferencia).HasColumnType("datetime2");
           builder.Property(p => p.DataVencimento).HasColumnType("datetime2").IsRequired();
           builder.Property(p => p.DataInativacao).HasColumnType("datetime2");
        }
    }
}