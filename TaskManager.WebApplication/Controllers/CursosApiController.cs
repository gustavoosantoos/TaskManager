using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Context;
using TaskManager.Data.Repositories;
using TaskManager.ServiceLayer;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Cursos")]
    public class CursosApiController : Controller
    {
        private readonly CursosServices _service;

        public CursosApiController(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            var userId = userManager.GetUserId(accessor.HttpContext.User);
            _service = new CursosServices(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var curso = _service.GetById(id);

            if (curso == null)
                return NotFound();

            return Ok(curso);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeletarCurso(id);
                return Ok(true);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}