﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240928234134_Ajuste campos de bool para descritivo da tabela Resposta para adequar a regra de negócio")]
    partial class AjustecamposdeboolparadescritivodatabelaRespostaparaadequararegradenegócio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Models.Atendimento.AtendimentoPacienteModel", b =>
                {
                    b.Property<int>("AtendimentoPacienteId")
                        .HasColumnType("int")
                        .HasColumnName("AtendimentoPacienteId");

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("SenhaClassificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AtendimentoPacienteId");

                    b.ToTable("Atendimento", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.CategoriaPerguntaModel", b =>
                {
                    b.Property<int>("CategoriaPerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoriaPerguntaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaPerguntaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Descricao");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.HasKey("CategoriaPerguntaId");

                    b.ToTable("CategoriaPergunta", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.ClassificacaoPacienteModel", b =>
                {
                    b.Property<int>("ClassificacaoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClassificacaoPacienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassificacaoPacienteId"));

                    b.Property<int>("AtendimentoPacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("PacienteId");

                    b.HasKey("ClassificacaoPacienteId");

                    b.ToTable("ClassificacaoPaciente", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.PerguntaModel", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PerguntaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerguntaId"));

                    b.Property<int?>("CategoriaPerguntaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("TextoPergunta")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("DescricaoPergunta");

                    b.HasKey("PerguntaId");

                    b.HasIndex("CategoriaPerguntaId");

                    b.ToTable("Pergunta", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.PerguntaSelecionadaModel", b =>
                {
                    b.Property<int>("PerguntaSelecionadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PerguntaSelecionadaPacienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerguntaSelecionadaId"));

                    b.Property<int>("ClassificacaoPacienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClassificacaoPacienteId");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int")
                        .HasColumnName("PerguntaId");

                    b.HasKey("PerguntaSelecionadaId");

                    b.ToTable("PerguntaSelecionada", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.RespostaModel", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RespostaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RespostaId"));

                    b.Property<int?>("IdPergunta")
                        .HasColumnType("int")
                        .HasColumnName("IdPergunta");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int?>("PontuacaoResposta")
                        .HasColumnType("int")
                        .HasColumnName("ValorResposta");

                    b.Property<string>("RespostaCheckBox")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("RespostaCheckBox");

                    b.Property<string>("RespostaComboBox")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("RespostaComboBox");

                    b.Property<DateTime?>("RespostaDateTime")
                        .HasColumnType("Datetime")
                        .HasColumnName("RespostaDateTime");

                    b.Property<int?>("RespostaNumeric")
                        .HasColumnType("int")
                        .HasColumnName("RespostaNumeric");

                    b.Property<string>("RespostaRadioButtom")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("RespostaRadioButtom");

                    b.Property<string>("RespostaTexto")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("RespostaTexto");

                    b.Property<string>("RespostaTextoArea")
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("RespostaTextoArea");

                    b.HasKey("RespostaId");

                    b.ToTable("Resposta", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.RespostaSelecionadaModel", b =>
                {
                    b.Property<int>("RespostaSelecionadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RespostaSelecionadaPacienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RespostaSelecionadaId"));

                    b.Property<int>("ClassificacaoPacienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClassificacaoPacienteId");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int");

                    b.Property<int>("RespostaId")
                        .HasColumnType("int");

                    b.Property<string>("ValorRespostaTexto")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ValorRespostaTexto");

                    b.Property<string>("ValorRespostaTextoArea")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ValorRespostaTextoArea");

                    b.HasKey("RespostaSelecionadaId");

                    b.ToTable("RespostaSelecionada", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.ResultadoModel", b =>
                {
                    b.Property<int>("ResultadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultadoId"));

                    b.Property<int>("ClassificacaoPacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("ResultadoClassificacaoCor")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ResultadoClassificacaoCor");

                    b.Property<int>("ResultadoCor")
                        .HasColumnType("int");

                    b.Property<int>("ValorResultadoClassificacao")
                        .HasColumnType("int");

                    b.HasKey("ResultadoId");

                    b.ToTable("Resultado", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Cliente.PacienteModel", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PacienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("bairro");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("municipio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("numero");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("profissao");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("rg");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("rua");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .HasColumnName("sexo");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("telefone");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("uf");

                    b.HasKey("PacienteId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Cliente.PacienteResponsavelModel", b =>
                {
                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteResponsavelId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.ToTable("PacienteResponsavel", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Cliente.ResponsavelModel", b =>
                {
                    b.Property<int>("ResponsavelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResponsavelId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponsavelId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("rg");

                    b.HasKey("ResponsavelId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.ToTable("Responsavel", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Funcionario.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("COREN")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("coren");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("crm");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<DateTime>("InseridoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("InseridoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("ModificadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ModificadoPor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("rg");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("senha");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("Celular")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Atendimento.AtendimentoPacienteModel", b =>
                {
                    b.HasOne("Infrastructure.Models.Classificacao.ClassificacaoPacienteModel", "ClassificacaoPaciente")
                        .WithOne("AtendimentoPaciente")
                        .HasForeignKey("Infrastructure.Models.Atendimento.AtendimentoPacienteModel", "AtendimentoPacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassificacaoPaciente");
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.PerguntaModel", b =>
                {
                    b.HasOne("Infrastructure.Models.Classificacao.CategoriaPerguntaModel", "CategoriaPergunta")
                        .WithMany()
                        .HasForeignKey("CategoriaPerguntaId");

                    b.Navigation("CategoriaPergunta");
                });

            modelBuilder.Entity("Infrastructure.Models.Classificacao.ClassificacaoPacienteModel", b =>
                {
                    b.Navigation("AtendimentoPaciente")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
