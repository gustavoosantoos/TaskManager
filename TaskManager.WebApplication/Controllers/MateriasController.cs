using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class MateriasController : BaseController
    {
        private MateriasServices _service;
        private MateriasRepository _repository;

        public MateriasController(MateriasRepository repository, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor) : base(userManager, accessor)
        {
            _repository = repository;
        }

        public IActionResult Index(int codigoCurso)
        {
            _service = new MateriasServices(_repository, codigoCurso);
            return View(_service.GetAll());
        }   
    }
}