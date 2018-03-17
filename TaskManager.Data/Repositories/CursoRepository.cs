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
        private readonly TaskManagerContext _context;
        private readonly IQueryable<Curso> _dbSetNotTrackable;

        public CursoRepository(TaskManagerContext context)
        {
            this._context = context;
            _dbSetNotTrackable = context.Cursos.AsNoTracking();
        }

        public Curso GetById(int id)
        {
            return _dbSetNotTrackable.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<Curso> GetAll()
        {
            return _dbSetNotTrackable;
        }

        public void Save(Curso curso)
        {
            if (curso.Id == default(int))
                _context.Cursos.Add(curso);
            else
                _context.Entry(curso).State = EntityState.Modified;
            
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var curso = _dbSetNotTrackable.FirstOrDefault(e => e.Id == id);
            if (curso == null)
                return;

            _context.Cursos.Remove(curso);
            _context.SaveChanges();
        }

        public DateTime GetDataCriacaoDoCurso(int codigoCurso)
        {
            return _dbSetNotTrackable.Where(e => e.Id == codigoCurso).Select(e => e.DataCriacao).Single();
        }
    }
}
