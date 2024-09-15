﻿using Infrastructure.Models.Classificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ContextConfiguration;

public class ResultadoConfiguration : IEntityTypeConfiguration<ResultadoModel>
{
    public void Configure(EntityTypeBuilder<ResultadoModel> builder)
    {
        builder.ToTable("Resultado");

        builder
            .HasKey(r => r.ResultadoId);

        builder.Property(r => r.ResultadoId);

        builder.Property(r => r.ResultadoClassificacaoCor)
               .HasColumnName("ResultadoClassificacaoCor")
               .HasColumnType("varchar(100)");

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
