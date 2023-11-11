using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaRPG.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataCriacao",
                table: "Racas",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DataCriacao",
                table: "Classes",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Racas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Classes");
        }
    }
}
