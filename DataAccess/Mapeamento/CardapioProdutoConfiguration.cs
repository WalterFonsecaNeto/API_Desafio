using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

public class CardapioProdutoConfiguration : IEntityTypeConfiguration<CardapioProduto>
{
    public void Configure(EntityTypeBuilder<CardapioProduto> builder)
    {
        builder.ToTable("CardapiosProdutos").HasKey(nameof(CardapioProduto.Id));
        builder.Property(nameof(CardapioProduto.Id)).HasColumnName("CardapioProdutoID").IsRequired(true);
        builder.Property(nameof(CardapioProduto.CardapioID)).HasColumnName("CardapioID").IsRequired(true);
        builder.Property(nameof(CardapioProduto.ProdutoID)).HasColumnName("ProdutoID").IsRequired(true);

        builder
            .HasOne(nameof(CardapioProduto.Cardapio))
            .WithMany(nameof(Cardapio.Produtos))
            .HasForeignKey(nameof(CardapioProduto.CardapioID))
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(nameof(CardapioProduto.Produto))
            .WithMany(nameof(Produto.Cardapios))
            .HasForeignKey(nameof(CardapioProduto.ProdutoID))
            .OnDelete(DeleteBehavior.NoAction);



    }

}