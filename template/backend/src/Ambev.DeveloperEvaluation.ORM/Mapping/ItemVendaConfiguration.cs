using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItensVenda");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(i => i.ProdutoId);
            builder.Property(i => i.ProdutoNome).HasMaxLength(300);
            builder.Property(i => i.Quantidade);
            builder.Property(i => i.PrecoUnitario);
            builder.Property(i => i.Desconto);
            builder.Property(i => i.Id); // chave estrangeira

            builder.HasOne(i => i.Venda)
                   .WithMany(v => v.Itens)
                   .HasForeignKey(i => i.VendaId);
        }
    }
}
