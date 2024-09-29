using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    /// <inheritdoc />
    public partial class removerrespostadatetimeeadicionarnatabelarespostaselecionada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaDateTime",
                table: "Resposta");

            migrationBuilder.AddColumn<DateTime>(
                name: "RespostaDateTime",
                table: "RespostaSelecionada",
                type: "Datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaDateTime",
                table: "RespostaSelecionada");

            migrationBuilder.AddColumn<DateTime>(
                name: "RespostaDateTime",
                table: "Resposta",
                type: "Datetime",
                nullable: true);
        }
    }
}
