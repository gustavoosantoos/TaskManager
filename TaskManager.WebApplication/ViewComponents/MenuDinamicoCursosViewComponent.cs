using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Data.Repositories;
using TaskManager.Domain.Models.Entities;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.ViewComponents
{
    public class MenuDinamicoCursosViewComponent : ViewComponent
    {
        private readonly TaskManagerContext context;
        private readonly CursoRepository repository;

        public MenuDinamicoCursosViewComponent(TaskManagerContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            this.context = context;
            repository = new CursoRepository(context, idUsuario: userManager.GetUserId(accessor.HttpContext.User));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await repository.GetAllAsync();
            return View(items);
        }
    }
}
