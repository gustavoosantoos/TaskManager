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
        public BaseController(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor, TaskManagerContext context)
        {
            UserManager = userManager;
            Accessor = accessor;
            Context = context;
            UserId = userManager.GetUserId(Accessor.HttpContext.User);
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public IHttpContextAccessor Accessor { get; }
        public TaskManagerContext Context { get; }
        public string UserId { get; }
    }
}