using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Context;
using TaskManager.Data.Repositories;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Cursos")]
    public class CursosApiController : Controller
    {
        public TaskManagerContext Context { get; set; }
        public UserManager<ApplicationUser> UserManager { get; set; }
        public IHttpContextAccessor Accessor { get; set; }
        public string UserId { get; set; }

        public CursosApiController(TaskManagerContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            Accessor = accessor;
            UserManager = userManager;
            Context = context;
            UserId = userManager.GetUserId(Accessor.HttpContext.User);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var repository = new CursoRepository(Context, UserId);
            var curso = repository.GetById(id);

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
                var repository = new CursoRepository(Context, UserId);
                repository.Delete(id);

                return Ok(true);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}