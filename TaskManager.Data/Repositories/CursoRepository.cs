using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Domain.Models.Entities;
using TaskManager.Utils.Validators;

namespace TaskManager.Data.Repositories
{
    public class CursoRepository
    {
        private readonly TaskManagerContext context;

        public CursoRepository(TaskManagerContext context)
        {
            this.context = context;
        }

        public Curso GetById(int id)
        {
            return context.Cursos.Find(id);
        }

        public IQueryable<Curso> GetAll()
        {
            return context.Cursos.AsNoTracking();
        }

        public void Save(Curso curso)
        {
            if (curso.Id == default(int))
                context.Cursos.Add(curso);
            else
                context.Entry(curso).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var curso = context.Cursos.Find(id);
            if (curso == null)
                return;

            context.Cursos.Remove(curso);
            context.SaveChanges();
        }

        public DateTime GetDataCriacaoDoCurso(int codigoCurso)
        {
            return context.Cursos.Where(e => e.Id == codigoCurso).Select(e => e.DataCriacao).Single();
        }
    }
}
