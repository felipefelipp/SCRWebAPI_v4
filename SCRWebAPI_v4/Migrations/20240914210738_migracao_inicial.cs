using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    /// <inheritdoc />
    public partial class migracao_inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "CategoriaPergunta",
                columns: table => new
                {
                    CategoriaPerguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPergunta", x => x.CategoriaPerguntaId);
                });


            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    numero = table.Column<int>(nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    municipio = table.Column<string>(type: "varchar(100)", nullable: false),
                    uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    sexo = table.Column<string>(type: "char(1)", nullable: false),
                    profissao = table.Column<string>(type: "varchar(50)", nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    rg = table.Column<string>(type: "varchar(8)", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_celular",
                table: "Paciente",
                column: "celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_cpf",
                table: "Paciente",
                column: "cpf",
                unique: true);


            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    ResponsavelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    rg = table.Column<string>(type: "varchar(8)", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.ResponsavelId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_celular",
                table: "Responsavel",
                column: "celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsavel_cpf",
                table: "Responsavel",
                column: "cpf",
                unique: true);


            migrationBuilder.CreateTable(
                name: "ClassificacaoPaciente",
                columns: table => new
                {
                    ClassificacaoPacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtendimentoPacienteId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacaoPaciente", x => x.ClassificacaoPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    AtendimentoPacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: false),
                    SenhaClassificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAtendimento = table.Column<DateTime>(nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.AtendimentoPacienteId);
                    
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    PerguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoPergunta = table.Column<string>(type: "varchar(250)", nullable: false),
                    CategoriaPerguntaId = table.Column<int>(nullable: true),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.PerguntaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_CategoriaPerguntaId",
                table: "Pergunta",
                column: "CategoriaPerguntaId");


            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    RespostaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespostaTexto = table.Column<bool>(nullable: false),
                    RespostaTextoArea = table.Column<bool>(nullable: false),
                    RespostaCheckBox = table.Column<string>(type: "varchar(100)", nullable: false),
                    RespostaComboBox = table.Column<string>(type: "varchar(100)", nullable: false),
                    RespostaRadioButtom = table.Column<string>(type: "varchar(100)", nullable: false),
                    RespostaData = table.Column<DateTime>(nullable: true),
                    ValorTipoResposta = table.Column<int>(nullable: false),
                    ValorResposta = table.Column<int>(nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.RespostaId);
                });


            migrationBuilder.CreateTable(
                name: "PerguntaSelecionadaPaciente",
                columns: table => new
                {
                    PerguntaSelecionadaPacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerguntaId = table.Column<int>(nullable: false),
                    RespostaId = table.Column<int>(nullable: false),
                    ValorRespostaTexto = table.Column<string>(type: "varchar(100)", nullable: true),
                    ValorRespostaTextoArea = table.Column<string>(type: "varchar(max)", nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    ClassificacaoPacienteId = table.Column<int>(nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaSelecionadaPaciente", x => x.PerguntaSelecionadaPacienteId);
                });


            migrationBuilder.CreateTable(
                name: "PacienteResponsavel",
                columns: table => new
                {
                    PacienteResponsavelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: false),
                    ResponsavelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteResponsavel", x => x.PacienteResponsavelId);
                });


            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    ResultadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DataResultado = table.Column<DateTime>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.ResultadoId);
                });


            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coren = table.Column<string>(type: "varchar(8)", nullable: false),
                    crm = table.Column<string>(type: "varchar(8)", nullable: false),
                    senha = table.Column<string>(type: "varchar(8)", nullable: false),
                    InseridoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    ModificadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(nullable: false, defaultValue: 1),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    rg = table.Column<string>(type: "varchar(8)", nullable: false),
                    celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_celular",
                table: "Usuario",
                column: "celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_cpf",
                table: "Usuario",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");


            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "PacienteResponsavel");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "PerguntaSelecionadaPaciente");

            migrationBuilder.DropTable(
                name: "Responsavel");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "RespostaSelecionadaPaciente");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "ClassificacaoPaciente");

            migrationBuilder.DropTable(
                name: "CategoriaPergunta");

            migrationBuilder.DropTable(
                name: "Paciente");

            

            migrationBuilder.DropTable(
                name: "Responsavel");


            migrationBuilder.DropTable(
                name: "ClassificacaoPaciente");


            migrationBuilder.DropTable(
                name: "Atendimento");


            migrationBuilder.DropTable(
                name: "Pergunta");


            migrationBuilder.DropTable(
                name: "Resposta");


            migrationBuilder.DropTable(
                name: "PerguntaSelecionadaPaciente");


            migrationBuilder.DropTable(
             name: "PacienteResponsavel");


            migrationBuilder.DropTable(
                name: "Resultado");


            migrationBuilder.DropTable(
                name: "Usuario");

        }
    }
}
