using System.Collections.Generic;
using ToDoOrNotToDo.Models;

namespace ToDoOrNotToDo.Repository
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int TodoId);
        void Insert(Todo todo);
        void Update(int id, Todo todo);
        void Delete(int id);
    }
}
