using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaRPG.Migrations
{
    /// <inheritdoc />
    public partial class TabelasAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Racas",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Personagens",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Equipamentos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Classes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<string>(
                name: "DataCriacao",
                table: "Racas",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DataCriacao",
                table: "Personagens",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DataCriacao",
                table: "Classes",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
