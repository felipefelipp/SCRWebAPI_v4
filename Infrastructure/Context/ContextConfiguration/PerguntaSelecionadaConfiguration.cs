using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class PerguntaSelecionadaConfiguration : IEntityTypeConfiguration<PerguntaSelecionadaModel>
{
    public void Configure(EntityTypeBuilder<PerguntaSelecionadaModel> builder)
    {
        builder
            .ToTable("PerguntaSelecionada");

        builder
            .HasKey(pspc => pspc.PerguntaSelecionadaId);

        builder
            .Property(pspc => pspc.PerguntaSelecionadaId)
            .HasColumnName("PerguntaSelecionadaPacienteId");

        builder
            .Property(pspc => pspc.PerguntaId)
            .HasColumnName("PerguntaId");

        builder
            .Property(pspc => pspc.ClassificacaoPacienteId)
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
