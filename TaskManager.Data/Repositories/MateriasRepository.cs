using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Context;
using TaskManager.Domain.Models.Entities;

namespace TaskManager.Data.Repositories
{
    public class MateriasRepository
    {
        private readonly TaskManagerContext _context;
        private readonly IQueryable<Materia> _dbSetNotTrackable; 

        public MateriasRepository(TaskManagerContext context)
        {
            _context = context;
            _dbSetNotTrackable = _context.Materias.AsNoTracking();
        }

        public IQueryable<Materia> GetAll()
        {
            return _dbSetNotTrackable;
        }

        public void Save(Materia materia)
        {
            if (materia.Id == default(int))
                _context.Materias.Add(materia);
            else
                _context.Entry(materia).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public Materia GetById(int id)
        { 
            return _dbSetNotTrackable.FirstOrDefault(e => e.Id == id);
        }

        public void Delete(int id)
        {
            var curso = _dbSetNotTrackable.FirstOrDefault(e => e.Id == id);
            if (curso == null)
                return;

            _context.Materias.Remove(curso);
            _context.SaveChanges();
        }

        public DateTime GetDataCriacaoDaMateria(int codigoMateria)
        {
            return _dbSetNotTrackable.Where(e => e.Id == codigoMateria).Select(e => e.DataCriacao).Single();
        }
    }
}
