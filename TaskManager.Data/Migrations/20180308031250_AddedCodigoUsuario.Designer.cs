﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TaskManager.Data.Context;

namespace TaskManager.Data.Migrations
{
    [DbContext(typeof(TaskManagerContext))]
    [Migration("20180308031250_AddedCodigoUsuario")]
    partial class AddedCodigoUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoUsuario")
                        .HasColumnName("Codigo_Usuario");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("MateriaId");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoUsuario")
                        .HasColumnName("Codigo_Usuario");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoUsuario")
                        .HasColumnName("Codigo_Usuario");

                    b.Property<int>("CursoId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(300);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaId");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnName("Codigo_Usuario");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime?>("DataFinalizacao");

                    b.Property<DateTime?>("DataLimite");

                    b.Property<DateTime>("DataUltimaAlteracao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500);

                    b.Property<bool>("IsDone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("TarefaPaiId");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TarefaPaiId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Categoria", b =>
                {
                    b.HasOne("TaskManager.Domain.Models.Entities.Materia")
                        .WithMany("Categorias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Materia", b =>
                {
                    b.HasOne("TaskManager.Domain.Models.Entities.Curso")
                        .WithMany("Materias")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskManager.Domain.Models.Entities.Tarefa", b =>
                {
                    b.HasOne("TaskManager.Domain.Models.Entities.Categoria")
                        .WithMany("Tarefas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskManager.Domain.Models.Entities.Tarefa", "TarefaPai")
                        .WithMany()
                        .HasForeignKey("TarefaPaiId");
                });
#pragma warning restore 612, 618
        }
    }
}
