using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class RespostaSelecionadaPacienteConfiguration : IEntityTypeConfiguration<RespostaSelecionadaPacienteModel>
{
    public void Configure(EntityTypeBuilder<RespostaSelecionadaPacienteModel> builder)
    {
        builder
            .ToTable("RespostaSelecionadaPaciente");

        builder
            .HasKey(rspc => rspc.RespostaSelecionadaPacienteId);

        builder
            .Property(rspc => rspc.RespostaSelecionadaPacienteId)
            .HasColumnName("RespostaSelecionadaPacienteId");

        builder
            .Property(rspc => rspc.ValorRespostaTexto)
            .HasColumnName("ValorRespostaTexto")
            .HasColumnType("varchar(100)")
            .IsRequired(false);

        builder
            .Property(rspc => rspc.ValorRespostaTextoArea)
            .HasColumnName("ValorRespostaTextoArea")
            .HasColumnType("varchar(max)")
            .IsRequired(false);

        builder
             .Property(rspc => rspc.ClassificacaoPacienteId)
             .HasColumnName("ClassificacaoPacienteId");

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
