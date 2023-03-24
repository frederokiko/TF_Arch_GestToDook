using Microsoft.AspNetCore.Mvc;
using TF_Arch_GestToDo.Dal.Entities;
using TF_Arch_GestToDo.Dal.Repositories;
using TF_Arch_GestTodoapi.models.form;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace TF_Arch_GestTodoapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public TodoApiController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<TodoApiController>
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_toDoRepository.Get().Select(t => new TodoSimple() { Id = t.Id, Title = t.Title }).ToList());

            //return Ok(_toDoRepository.Get()) ;

        }

        
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            ToDo? todo = _toDoRepository.Get(id);

            if (todo is null)
                return RedirectToAction("Index");

            //return Ok(_toDoRepository.Get().Select(t => new TodoComplet() { Id = t.Id, Title = t.Title,Done=t.Done}));
            return Ok(new TodoComplet() { Id = todo.Id, Title = todo.Title, Done = todo.Done });
        }

        // POST api/<TodoApiController>
        [HttpPost]
      
            public IActionResult Create(CreeTodo form)
            {
             
                if (_toDoRepository.Create(new ToDo() { Title = form.Title }))
                {
                return NoContent();
                }
                else
                {
                   
                    return BadRequest();
                }
            }
        


        // PUT api/<TodoApiController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(int id, update form)
        {
          

            if (id != form.Id)
                return BadRequest();

            if (_toDoRepository.Update(new ToDo() { Id = id, Title = form.Title, Done = form.Done }))
            {
                return Ok();
            }
            else
            {
                
                return BadRequest();
            }
        }


        // DELETE api/<TodoApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (_toDoRepository.Delete(id))
            {
                return Ok();
            }
            else
            {             
                return BadRequest();
            }
        }

    }
}
