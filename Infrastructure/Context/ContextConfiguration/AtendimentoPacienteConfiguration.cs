using Infrastructure.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class AtendimentoPacienteConfiguration : IEntityTypeConfiguration<AtendimentoPacienteModel>
{
    public void Configure(EntityTypeBuilder<AtendimentoPacienteModel> builder)
    {
        builder.ToTable("Atendimento");

        builder
            .HasKey(a => a.AtendimentoPacienteId);

        builder
            .Property(a => a.AtendimentoPacienteId)
            .HasColumnName("AtendimentoPacienteId"); 

        builder.HasKey(a => a.AtendimentoPacienteId);

        builder
            .HasOne(c => c.ClassificacaoPaciente)
            .WithOne(a => a.AtendimentoPaciente)
            .HasForeignKey<AtendimentoPacienteModel>(a => a.AtendimentoPacienteId);

        builder
            .Property<DateTime>("InseridoEm")
            .HasColumnType("datetime")
            .HasDefaultValueSql("getdate()");

        builder
            .Property<int>("InseridoPor")
            .HasColumnType("int")
            .HasDefaultValueSql("1"); //Implementar inserido por usuário X ou Y

        builder
            .Property<DateTime>("ModificadoEm")
            .HasColumnType("datetime")
            .HasDefaultValueSql("getdate()"); //Implementar modificado em 

        builder
            .Property<int>("ModificadoPor")
            .HasColumnType("int")
            .HasDefaultValueSql("1"); //Implementar usuário que modificou
    }
}
