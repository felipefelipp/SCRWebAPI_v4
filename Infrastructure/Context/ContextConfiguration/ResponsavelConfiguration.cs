using Infrastructure.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class ResponsavelConfiguration : PessoaConfiguration<ResponsavelModel>
{
    public override void Configure(EntityTypeBuilder<ResponsavelModel> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Responsavel");

        builder
            .HasKey(r => r.ResponsavelId);

        builder
            .Property(r => r.ResponsavelId)
            .HasColumnName("ResponsavelId");

        builder
            .HasKey(r => r.ResponsavelId);

    }
}
