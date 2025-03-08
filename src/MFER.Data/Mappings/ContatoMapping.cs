using MFER.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFER.Data.Mappings;

public class ContatoMapping : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("Contatos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(c => c.Email)
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(c => c.Telefone)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(c => c.Mensagem)
            .HasColumnType("varchar(200)")
            .IsRequired(false);
    }
}