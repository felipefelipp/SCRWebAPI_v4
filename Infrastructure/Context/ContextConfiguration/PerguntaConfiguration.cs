using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class PerguntaConfiguration : IEntityTypeConfiguration<PerguntaModel>
{
    public void Configure(EntityTypeBuilder<PerguntaModel> builder)
    {
        builder
            .ToTable("Pergunta");

        builder
            .HasKey(p => p.PerguntaId);

        builder
            .Property(p => p.PerguntaId)
            .HasColumnName("PerguntaId");

        builder
            .Property(p => p.TextoPergunta)
            .HasColumnName("DescricaoPergunta")
            .HasColumnType("varchar(250)")
            .IsRequired();

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
