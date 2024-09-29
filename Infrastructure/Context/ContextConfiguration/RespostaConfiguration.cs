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
            .HasColumnType("varchar(50)")
            .IsRequired(false);

        builder
            .Property(r => r.RespostaTextoArea)
            .HasColumnName("RespostaTextoArea")
            .HasColumnType("varchar(1000)")
            .IsRequired(false);


        builder
            .Property(r => r.RespostaCheckBox)
            .HasColumnName("RespostaCheckBox")
            .HasColumnType("varchar(100)")
            .IsRequired(false);

        builder
            .Property(r => r.RespostaComboBox)
            .HasColumnName("RespostaComboBox")
            .HasColumnType("varchar(100)")
            .IsRequired(false);

        builder
            .Property(r => r.RespostaRadioButtom)
            .HasColumnName("RespostaRadioButtom")
            .HasColumnType("varchar(100)")
            .IsRequired(false);

        builder
            .Property(r => r.RespostaNumeric)
            .HasColumnName("RespostaNumeric")
            .HasColumnType("int")
            .IsRequired(false);

        builder
            .Property(r => r.PontuacaoResposta)
            .HasColumnName("PontuacaoResposta")
            .IsRequired(false);

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
