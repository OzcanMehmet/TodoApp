using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDo.Service;
using ToDo.Web.Models;

namespace ToDo.Web.Controllers
{
    public class HomeController : Controller
    {

        private ITodoService _todoService;
        public HomeController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            return View(_todoService.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entity.ToDo entity)
        {
            if(ModelState.IsValid)
            {
                _todoService.Insert(entity);
                Console.WriteLine("xyz");
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var todo = _todoService.FindById((int)id);
            if (todo == null)
            {
                return NotFound();
            }
            _todoService.Delete(todo);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Entity.ToDo toDo = _todoService.FindById(id);
            if (toDo == null)
                return NotFound();
            return View(toDo);
        }

        [HttpPost]
        public ActionResult Edit(Entity.ToDo entity)
        {
            Entity.ToDo toDo = _todoService.FindById(entity.Id);
            if (toDo == null)
                return NotFound();
            _todoService.Update(entity);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
