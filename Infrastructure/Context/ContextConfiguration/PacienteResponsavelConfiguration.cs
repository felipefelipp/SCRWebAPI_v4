using Infrastructure.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class PacienteResponsavelConfiguration : IEntityTypeConfiguration<PacienteResponsavelModel>
{
    public void Configure(EntityTypeBuilder<PacienteResponsavelModel> builder)
    {
        builder.ToTable("PacienteResponsavel");

        builder.HasNoKey();
    }
}
