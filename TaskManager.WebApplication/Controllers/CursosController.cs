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
using TaskManager.ServiceLayer;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.Controllers
{
    [Authorize]
    public class CursosController : BaseController
    {
        private readonly CursosServices _service;
        public CursosController(CursoRepository repository, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor) : base(userManager, accessor)
        {
            _service = new CursosServices(repository, _codigoUsuario);
        }

        public ActionResult Listar()
        {
            TempData["GerenciarCursosMenu"] = "active";
            List<Curso> cursos = _service.GetAll();
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
                    _service.SalvarCurso(curso);
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
            var curso = _service.GetById(id);
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
                    _service.SalvarCurso(curso);
                    return RedirectToAction(actionName: nameof(Listar));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}