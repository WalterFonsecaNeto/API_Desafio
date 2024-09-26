using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
   public void Configure(EntityTypeBuilder<Produto> builder)
   {
      builder.ToTable("Produtos").HasKey(nameof(Produto.Id));
      builder.Property(nameof(Produto.Id)).HasColumnName("ProdutoID").IsRequired(true);
      builder.Property(nameof(Produto.Nome)).HasColumnName("NomeProduto").IsRequired(true);
      builder.Property(nameof(Produto.Preco)).HasColumnName("PrecoProduto").IsRequired(true).HasColumnType("decimal(18, 2)");
      

   }

}