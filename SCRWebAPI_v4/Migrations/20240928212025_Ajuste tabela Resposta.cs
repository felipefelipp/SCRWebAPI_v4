using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjustetabelaResposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPergunta",
                table: "Resposta",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPergunta",
                table: "Resposta");
        }
    }
}
