using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class CategoriaPerguntaConfiguration : IEntityTypeConfiguration<CategoriaPerguntaModel>
{
    public void Configure(EntityTypeBuilder<CategoriaPerguntaModel> builder)
    {
        builder
            .ToTable("CategoriaPergunta");

        builder.HasKey(cp => cp.CategoriaPerguntaId);

        builder
            .Property(cp => cp.CategoriaPerguntaId)
            .HasColumnName("CategoriaPerguntaId");

        builder
            .Property(cp => cp.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("varchar(100)")
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
