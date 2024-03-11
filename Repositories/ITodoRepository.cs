using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public interface ITodoRepository
    {
        Todo GetById(int id);
        IEnumerable<Todo> List();
        void Insert(Todo entity);
        void Delete(Todo entity);
        void Update(Todo entity);
    }
}
