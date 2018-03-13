using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskManager.Data.Migrations
{
    public partial class AddedCodigoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo_Usuario",
                table: "Tarefas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo_Usuario",
                table: "Materias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo_Usuario",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo_Usuario",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Codigo_Usuario",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Codigo_Usuario",
                table: "Categorias");
        }
    }
}
