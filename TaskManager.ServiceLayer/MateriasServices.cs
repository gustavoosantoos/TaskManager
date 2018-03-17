using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Data.Repositories;
using TaskManager.Domain.Models.Entities;
using TaskManager.Utils.DependencyInjection;

namespace TaskManager.ServiceLayer
{
    public class MateriasServices
    {
        private readonly MateriasRepository _repository;
        private readonly int _codigoCurso;

        public MateriasServices(int codigoCurso)
        {
            _repository = AppDependencyResolver.Current.GetService<MateriasRepository>();
            _codigoCurso = codigoCurso;
        }

        public List<Materia> GetAll()
        {
            return _repository.GetAll().Where(e => e.CursoId == _codigoCurso).ToList();
        }

        public void SalvarCurso(Materia materia)
        {
            if (materia.Id != default(int))
                materia.DataCriacao = _repository.GetDataCriacaoDaMateria(materia.Id);
            else
                materia.DataCriacao = DateTime.Now;
            materia.DataUltimaAlteracao = DateTime.Now;

            materia.CursoId = _codigoCurso;
            _repository.Save(materia);
        }

        public void DeletarCurso(int codigoCurso)
        {
            _repository.Delete(codigoCurso);
        }
    }
}
