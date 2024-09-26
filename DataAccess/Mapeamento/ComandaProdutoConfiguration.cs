using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

public class ComandaProdutoConfiguration : IEntityTypeConfiguration<ComandaProduto>
{
    public void Configure(EntityTypeBuilder<ComandaProduto> builder)
    {
        builder.ToTable("ComandasProdutos").HasKey(nameof(ComandaProduto.Id));
        builder.Property(nameof(ComandaProduto.Id)).HasColumnName("ComandaProdutoID").IsRequired(true);
        builder.Property(nameof(ComandaProduto.ComandaID)).HasColumnName("ComandaID").IsRequired(true);
        builder.Property(nameof(ComandaProduto.ProdutoID)).HasColumnName("ProdutoID").IsRequired(true);

        builder
            .HasOne(nameof(ComandaProduto.Comanda))
            .WithMany(nameof(Comanda.Produtos))
            .HasForeignKey(nameof(ComandaProduto.ComandaID))
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(nameof(ComandaProduto.Produto))
            .WithMany(nameof(Produto.Comandas))
            .HasForeignKey(nameof(ComandaProduto.ProdutoID))
            .OnDelete(DeleteBehavior.NoAction);



    }

}