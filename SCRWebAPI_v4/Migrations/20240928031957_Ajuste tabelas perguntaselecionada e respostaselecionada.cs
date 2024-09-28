using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    /// <inheritdoc />
    public partial class Ajustetabelasperguntaselecionadaerespostaselecionada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerguntaSelecionadaPaciente");

            migrationBuilder.CreateTable(
                name: "PerguntaSelecionada",
                columns: table => new
                {
                    PerguntaSelecionadaPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaSelecionada", x => x.PerguntaSelecionadaPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "RespostaSelecionada",
                columns: table => new
                {
                    RespostaSelecionadaPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    RespostaId = table.Column<int>(type: "int", nullable: false),
                    ValorRespostaTexto = table.Column<string>(type: "varchar(100)", nullable: true),
                    ValorRespostaTextoArea = table.Column<string>(type: "varchar(max)", nullable: true),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaSelecionada", x => x.RespostaSelecionadaPacienteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerguntaSelecionada");

            migrationBuilder.DropTable(
                name: "RespostaSelecionada");

            migrationBuilder.CreateTable(
                name: "PerguntaSelecionadaPaciente",
                columns: table => new
                {
                    PerguntaSelecionadaPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    PerguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaSelecionadaPaciente", x => x.PerguntaSelecionadaPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "RespostaSelecionadaPaciente",
                columns: table => new
                {
                    RespostaSelecionadaPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassificacaoPacienteId = table.Column<int>(type: "int", nullable: false),
                    InseridoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InseridoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    ModificadoEm = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    RespostaId = table.Column<int>(type: "int", nullable: false),
                    ValorRespostaTexto = table.Column<string>(type: "varchar(100)", nullable: true),
                    ValorRespostaTextoArea = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaSelecionadaPaciente", x => x.RespostaSelecionadaPacienteId);
                });
        }
    }
}
