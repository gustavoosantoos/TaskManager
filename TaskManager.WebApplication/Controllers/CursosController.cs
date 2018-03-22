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
using TaskManager.Utils.ClientSide.Alerts;
using TaskManager.WebApplication.Filters;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.Controllers
{
    [Authorize]
    [UserFriendlyExceptionFilter]
    public class CursosController : BaseController
    {
        private readonly CursosServices _service;
        public CursosController(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor) : base(userManager, accessor)
        {
            _service = new CursosServices(_codigoUsuario);
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

            if (ModelState.IsValid)
            {
                _service.SalvarCurso(curso);
                return RedirectToAction(actionName: nameof(Listar));
            }

            return View();
        }

        // GET: Cursos/Editar
        public ActionResult Editar(int id)
        {
            var curso = _service.GetById(id);
            return View(curso);
        }

        // POST: Curso/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _service.SalvarCurso(curso);
                return RedirectToAction(actionName: nameof(Listar));
            }

            return View();
        }
    }
}