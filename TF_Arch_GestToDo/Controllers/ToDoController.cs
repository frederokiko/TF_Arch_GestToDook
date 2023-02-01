using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TF_Arch_GestToDo.Dal.Entities;
using TF_Arch_GestToDo.Dal.Repositories;
using TF_Arch_GestToDo.Infrastructure;
using TF_Arch_GestToDo.Models.Forms;

namespace TF_Arch_GestToDo.Controllers
{
    [TypeFilter(typeof(ExceptionFilter))]
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        // GET: ToDoController
        public IActionResult Index()
        {
            return View(_repository.Get().Select(t => new DisplayTodo() { Id = t.Id, Title = t.Title }).ToList());
        }

        // GET: ToDoController/Details/5
        public IActionResult Details(int id)
        {
            ToDo? todo = _repository.Get(id);

            if (todo is null)
                return RedirectToAction("Index");

            return View(new DisplayTodoFull() { Id = todo.Id, Title = todo.Title, Done = todo.Done });
        }

        // GET: ToDoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateToDo form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if (_repository.Create(new ToDo() { Title = form.Title }))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Quelque chose n'a pas fonctionné comme prévu, merci de contacter l'admin du site...");
                return View(form);
            }
        }

        // GET: ToDoController/Edit/5
        public IActionResult Edit(int id)
        {
            ToDo? todo = _repository.Get(id);

            if (todo is null)
                return RedirectToAction("Index");

            return View(new EditToDo() { Id = todo.Id, Title = todo.Title, Done = todo.Done});
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditToDo form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if(id != form.Id)
                return RedirectToAction("Index");

            if (_repository.Update(new ToDo() { Id = id, Title = form.Title, Done = form.Done }))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Quelque chose n'a pas fonctionné comme prévu, merci de contacter l'admin du site...");
                return View(form);
            }
        }

        // GET: ToDoController/Delete/5
        public IActionResult Delete(int id)
        {
            ToDo? todo = _repository.Get(id);

            if (todo is null)
                return RedirectToAction("Index");


            return View(new DisplayTodoFull() { Id = todo.Id, Title = todo.Title, Done = todo.Done });
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (_repository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Quelque chose n'a pas fonctionné comme prévu, merci de contacter l'admin du site...");
                return View();
            }
        }
    }
}
