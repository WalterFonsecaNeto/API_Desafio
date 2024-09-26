using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio;

namespace DataAccess;

public class CardapioConfiguration : IEntityTypeConfiguration<Cardapio>
{
    public void Configure(EntityTypeBuilder<Cardapio> builder)
    {
        builder.ToTable("Cardapio").HasKey(nameof(Cardapio.Id));
        builder.Property(nameof(Cardapio.Id)).HasColumnName("CardapioID").IsRequired(true);
        builder.Property(nameof(Cardapio.Disponibilidade)).HasColumnName("Disponibilidade").IsRequired(true);


    }

}