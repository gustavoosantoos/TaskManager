using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskManager.Data.Migrations
{
    public partial class AddedFks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Materias_MateriaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Cursos_CursoId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Tarefas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Materias",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "Categorias",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Materias_MateriaId",
                table: "Categorias",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Cursos_CursoId",
                table: "Materias",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Materias_MateriaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Cursos_CursoId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Tarefas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Materias",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Materias_MateriaId",
                table: "Categorias",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Cursos_CursoId",
                table: "Materias",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
