using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Context;
using TaskManager.Data.Repositories;
using TaskManager.Domain.Models.Entities;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.Controllers
{
    [Authorize]
    public class CursosController : BaseController
    {
        public CursosController(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor, TaskManagerContext context) : base(userManager, accessor, context)
        {
        }

        public ActionResult Listar()
        {
            TempData["GerenciarCursosMenu"] = "active";
            List<Curso> cursos = new CursoRepository(Context, UserId).GetAll();
            return View(cursos);
        }

        // GET: Cursos/Adicionar
        public ActionResult Adicionar()
        {
            return View();
        }

        // POST: Cursos/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    curso.CodigoUsuario = UserId;
                    SalvarCurso(curso, isNewCadastro: true);
                    return RedirectToAction(actionName: nameof(Listar));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            var curso = new CursoRepository(Context, UserId).GetById(id);
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalvarCurso(curso, isNewCadastro: false);
                    return RedirectToAction(actionName: nameof(Listar));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        private void SalvarCurso(Curso curso, bool isNewCadastro)
        {
            if (isNewCadastro)
                curso.DataCriacao = DateTime.Now;

            curso.DataUltimaAlteracao = DateTime.Now;

            var repository = new CursoRepository(Context, UserId);
            repository.Save(curso);
        }
    }
}