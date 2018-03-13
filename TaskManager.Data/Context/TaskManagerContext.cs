using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskManager.Domain.Models.Entities;

namespace TaskManager.Data.Context
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
        }

        public DbSet<TaskManager.Domain.Models.Entities.Curso> Cursos { get; set; }
        public DbSet<TaskManager.Domain.Models.Entities.Materia> Materias { get; set; }
        public DbSet<TaskManager.Domain.Models.Entities.Categoria> Categorias { get; set; }
        public DbSet<TaskManager.Domain.Models.Entities.Tarefa> Tarefas { get; set; }
    }
}
