using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoOrNotToDo.Models;
using ToDoOrNotToDo.Repository;

namespace ToDoOrNotToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController: ControllerBase
    {
        private ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        [Route("/todo")]
        public IEnumerable<Todo> GetAll()
        {
            return _todoRepository.GetAll();
        }

        [HttpGet]
        [Route("/todo/{id:int}")]
        public Todo Get(int id)
        {
            return _todoRepository.GetById(id);
        }

        [HttpPost]
        public void Post(Todo todo)
        {
            _todoRepository.Insert(todo);
            return;
        }

        [HttpPut]
        [Route("/todo/{id:int}")]
        public void Put(int id, Todo updatedTodo)
        {
            _todoRepository.Update(id, updatedTodo);
        }

        [HttpDelete]
        [Route("/todo/{id:int}")]
        public void Delete(int id)
        {
            _todoRepository.Delete(id);
        }
    }
}
