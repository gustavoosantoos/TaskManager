using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TaskManager.Data.Repositories;
using TaskManager.Domain.Models.Entities;
using TaskManager.Utils.DependencyInjection;
using TaskManager.Utils.Validators;

namespace TaskManager.ServiceLayer
{
    public class CursosServices
    {
        private readonly CursoRepository _repository;
        private readonly string _codigoUsuario;

        public CursosServices(string codigoUsuario)
        {
            _repository = AppDependencyResolver.Current.GetService<CursoRepository>();
            _codigoUsuario = codigoUsuario;
        }

        public Curso GetById(int codigoCurso)
        {
            return _repository.GetById(codigoCurso);
        }

        public List<Curso> GetAll()
        {
            return _repository.GetAll().Where(e => e.CodigoUsuario == _codigoUsuario).ToList();
        }

        public void SalvarCurso(Curso curso)
        {
            if (curso.Id != default(int))
                curso.DataCriacao = _repository.GetDataCriacaoDoCurso(curso.Id);
            else
                curso.DataCriacao = DateTime.Now;
            curso.DataUltimaAlteracao = DateTime.Now;

            curso.CodigoUsuario = _codigoUsuario;
            _repository.Save(curso);
        }

        public void DeletarCurso(int codigoCurso)
        {
            _repository.Delete(codigoCurso);
        }
    }
}
