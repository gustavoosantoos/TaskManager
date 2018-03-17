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

        public MateriasRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public IQueryable<Materia> GetAll()
        {
            return _context.Materias.AsNoTracking();
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
            return _context.Materias.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public void Delete(int id)
        {
            var curso = _context.Materias.Find(id);
            if (curso == null)
                return;

            _context.Materias.Remove(curso);
            _context.SaveChanges();
        }

        public DateTime GetDataCriacaoDaMateria(int codigoMateria)
        {
            return _context.Materias.Where(e => e.Id == codigoMateria).Select(e => e.DataCriacao).Single();
        }
    }
}
