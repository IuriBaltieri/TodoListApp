using Microsoft.EntityFrameworkCore;

using TodoListApp.Contexts;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _dbContext;

        public TodoRepository(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Todo GetById(int id)
        {
            return _dbContext.Set<Todo>().Find(id);
        }

        public IEnumerable<Todo> List()
        {
            return _dbContext.Set<Todo>().AsEnumerable();
        }

        public void Insert(Todo entity)
        {
            _dbContext.Set<Todo>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Todo entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Todo entity)
        {
            _dbContext.Set<Todo>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
