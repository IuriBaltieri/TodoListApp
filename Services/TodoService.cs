using TodoListApp.Models;
using TodoListApp.Repositories;

namespace TodoListApp.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public Todo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Todo> List()
        {
            return _repository.List();
        }

        public void Insert(Todo entity)
        {
            _repository.Insert(entity);
        }

        public void Delete(Todo entity)
        {
            _repository.Delete(entity);
        }

        public void Update(Todo entity)
        {
            _repository.Update(entity);
        }
    }
}
