using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.NumeroVenda);
            builder.Property(u => u.DataVenda);
            builder.Property(u => u.ClienteId);
            builder.Property(u => u.ClienteNome).HasMaxLength(300);

            builder.Property(u => u.ClienteNome).HasMaxLength(300);
            builder.Property(u => u.FilialId);
            builder.Property(u => u.Cancelada);

            builder.HasMany(v => v.Itens)
            .WithOne(i => i.Venda)
            .HasForeignKey(i => i.VendaId)
            .OnDelete(DeleteBehavior.Cascade); // ou Restrict, conforme regra de negócio


        }
    }
}
