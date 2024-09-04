using EasyControl.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyControl.Api.Data.Mappings
{
    public class AreceberMap : IEntityTypeConfiguration<Areceber>
    {
        public void Configure(EntityTypeBuilder<Areceber> builder)
        {
           builder.ToTable("TituloAreceber").HasKey(p => p.Id);
           builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(fk => fk.IdUsuario).OnDelete(DeleteBehavior.Restrict);;
           builder.HasOne(p => p.NaturezaDeLancamento).WithMany().HasForeignKey(fk => fk.IdNaturezaDeLancamento);
           builder.Property(p => p.Descricao).HasColumnType("VARCHAR(500)").IsRequired();
           builder.Property(p => p.Observacao).HasColumnType("VARCHAR(500)");
           builder.Property(p => p.ValorOriginal).HasColumnType("double precision").IsRequired();
           builder.Property(p => p.ValorRecebido).HasColumnType("double precision").IsRequired();
           builder.Property(p => p.DataCadastro).HasColumnType("datetime2").IsRequired();
           builder.Property(p => p.DataRecebimento).HasColumnType("datetime2");
           builder.Property(p => p.DataReferencia).HasColumnType("datetime2");
           builder.Property(p => p.DataVencimento).HasColumnType("datetime2").IsRequired();
           builder.Property(p => p.DataInativacao).HasColumnType("datetime2");
        }
    }
}