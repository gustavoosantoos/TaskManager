using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Domain.Models.Entities;
using TaskManager.Domain.Util;

namespace TaskManager.Data.Repositories
{
    public class CursoRepository
    {
        private TaskManagerContext context;
        private string idUsuario;

        public CursoRepository(TaskManagerContext context, string idUsuario)
        {
            this.context = context;
            this.idUsuario = idUsuario;
        }

        public Curso GetById(int id)
        {
            return context.Cursos.Find(id);
        }

        public List<Curso> GetAll()
        {
            return context.Cursos.AsNoTracking().Where(e => e.CodigoUsuario == idUsuario).ToList();
        }

        public Task<List<Curso>> GetAllAsync()
        {
            return context.Cursos.AsNoTracking().Where(e => e.CodigoUsuario == idUsuario).ToListAsync();
        }


        public bool Save(Curso curso)
        {
            if (ObjectValidator.IsValid(curso) == false)
                throw new ArgumentException("O parâmetro não é válido.");

            if (curso.Id == default(int))
            {
                curso.CodigoUsuario = idUsuario;
                context.Cursos.Add(curso);
            }
            else
            {
                curso.CodigoUsuario = idUsuario;
                context.Entry(curso).State = EntityState.Modified;
            }

            context.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            var curso = context.Cursos.Find(id);
            curso.CodigoUsuario = idUsuario;
            if (curso == null)
                return;

            context.Cursos.Remove(curso);
            context.SaveChanges();
        }
    }
}
