using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRWebAPI_v4.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjustecamposdeboolparadescritivodatabelaRespostaparaadequararegradenegócio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTipoResposta",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "RespostaData",
                table: "Resposta",
                newName: "RespostaDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "ValorResposta",
                table: "Resposta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RespostaTextoArea",
                table: "Resposta",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "RespostaTexto",
                table: "Resposta",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "RespostaRadioButtom",
                table: "Resposta",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "RespostaComboBox",
                table: "Resposta",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "RespostaCheckBox",
                table: "Resposta",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<int>(
                name: "RespostaNumeric",
                table: "Resposta",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaNumeric",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "RespostaDateTime",
                table: "Resposta",
                newName: "RespostaData");

            migrationBuilder.AlterColumn<int>(
                name: "ValorResposta",
                table: "Resposta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RespostaTextoArea",
                table: "Resposta",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RespostaTexto",
                table: "Resposta",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RespostaRadioButtom",
                table: "Resposta",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RespostaComboBox",
                table: "Resposta",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RespostaCheckBox",
                table: "Resposta",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorTipoResposta",
                table: "Resposta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
