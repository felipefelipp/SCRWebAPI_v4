using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    /// <inheritdoc />
    public partial class ajustecolunaRespostaSelecionadaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RespostaSelecionadaPacienteId",
                table: "RespostaSelecionada",
                newName: "RespostaSelecionadaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RespostaSelecionadaId",
                table: "RespostaSelecionada",
                newName: "RespostaSelecionadaPacienteId");
        }
    }
}
