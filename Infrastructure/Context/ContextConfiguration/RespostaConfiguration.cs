using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class RespostaConfiguration : IEntityTypeConfiguration<RespostaModel>
{
    public void Configure(EntityTypeBuilder<RespostaModel> builder)
    {
        builder
            .ToTable("Resposta");

        builder
            .HasKey(r => r.RespostaId);

        builder
            .Property(r => r.RespostaId)
            .HasColumnName("RespostaId");

        builder
            .Property(r => r.RespostaTexto)
            .HasColumnName("RespostaTexto")
            .HasColumnType("bit");

        builder
            .Property(r => r.RespostaTextoArea)
            .HasColumnName("RespostaTextoArea")
            .HasColumnType("bit");

        builder
            .Property(r => r.RespostaCheckBox)
            .HasColumnName("RespostaCheckBox")
            .HasColumnType("varchar(100)");

        builder
            .Property(r => r.RespostaComboBox)
            .HasColumnName("RespostaComboBox")
            .HasColumnType("varchar(100)");

        builder
            .Property(r => r.RespostaRadioButtom)
            .HasColumnName("RespostaRadioButtom")
            .HasColumnType("varchar(100)");

        builder
            .Property(r => r.RespostaData)
            .HasColumnName("RespostaData")
            .HasColumnType("Datetime");

        builder
            .Property(r => r.ValorTipoResposta)
            .HasColumnName("ValorTipoResposta");

        builder
            .Property(r => r.ValorResposta)
            .HasColumnName("ValorResposta");

        builder
            .Ignore(r => r.TipoResposta);

        builder
            .Property(r => r.IdPergunta)
            .HasColumnName("IdPergunta")
            .IsRequired(false);

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
