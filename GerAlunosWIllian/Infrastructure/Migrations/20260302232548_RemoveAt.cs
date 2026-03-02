using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerAlunosWIllian.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemovedAt",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                table: "Cursos",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                table: "Alunos",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
