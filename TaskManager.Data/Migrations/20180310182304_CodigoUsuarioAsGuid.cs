using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskManager.Data.Migrations
{
    public partial class CodigoUsuarioAsGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Codigo_Usuario",
                table: "Cursos",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Codigo_Usuario",
                table: "Cursos",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
