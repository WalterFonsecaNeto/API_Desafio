using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

public class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
{
   public void Configure(EntityTypeBuilder<Comanda> builder)
   {
      builder.ToTable("Comandas").HasKey(nameof(Comanda.Id));
      builder.Property(nameof(Comanda.Id)).HasColumnName("ComandaID").IsRequired(true);
      builder.Property(nameof(Comanda.Mesa)).HasColumnName("Mesa").IsRequired(true);
      builder.Property(nameof(Comanda.NomeGarcom)).HasColumnName("NomeGarcom").IsRequired(true);
      builder.Property(nameof(Comanda.Data)).HasColumnName("Data").IsRequired(true);
      

   }

}