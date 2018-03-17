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
using TaskManager.ServiceLayer;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.ViewComponents
{
    public class MenuDinamicoCursosViewComponent : ViewComponent
    {
        private readonly CursosServices _service;

        public MenuDinamicoCursosViewComponent(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _service = new CursosServices(userManager.GetUserId(accessor.HttpContext.User));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _service.GetAll();
            return View(items);
        }
    }
}
