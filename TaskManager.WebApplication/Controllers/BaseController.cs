using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Context;
using TaskManager.WebApplication.Models;

namespace TaskManager.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _accessor = accessor;
            _codigoUsuario = userManager.GetUserId(_accessor.HttpContext.User);
        }

        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly IHttpContextAccessor _accessor;
        protected readonly string _codigoUsuario;
    }
}