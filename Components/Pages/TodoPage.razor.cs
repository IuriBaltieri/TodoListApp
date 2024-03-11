using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp.Components.Pages
{
    public partial class TodoPage
    {
        [Inject] public TodoService TodoService { get; set; } = default!;

        public Todo Todo { get; set; } = new();
        public List<Todo> TodoList = new();
        IQueryable<Todo> TodoQueryable = Enumerable.Empty<Todo>().AsQueryable();

        protected override void OnInitialized()
        {
            TodoList = GetTodoList();

            ConvertListToQueryable();
        }

        public void Add()
        {
            if (string.IsNullOrEmpty(Todo.Name))
                return;

            // Update
            if (Todo.Id > 0)
            {
                TodoService.Update(Todo);

                GetDataAgain();

                return;
            }

            //Add
            TodoService.Insert(Todo);

            GetDataAgain();

            return;
        }

        private void Edit(Todo incomingModel)
        {
            Todo = incomingModel;
        }

        private void Delete(Todo incomingModel)
        {
            TodoService.Delete(incomingModel);

            GetDataAgain();
        }

        private void Complete(Todo todoModel)
        {
            todoModel.Completed = true;

            TodoService.Update(todoModel);
        }

        private bool IsCompleted(Todo todoModel) => todoModel.Completed;

        private void HandleComplete(Todo todoModel)
        {
            if (IsCompleted(todoModel))
            {
                InComplete(todoModel);
            }
            else
            {
                Complete(todoModel);
            }

            GetDataAgain();
        }

        private void InComplete(Todo todoModel)
        {
            todoModel.Completed = false;

            TodoService.Update(todoModel);
        }

        private void ClearForm()
        {
            Todo = new();
        }

        private List<Todo> GetTodoList()
        {
            var todoIEnum = TodoService.List();

            return todoIEnum?.ToList() ?? new();
        }

        private void ConvertListToQueryable()
        {
            if (TodoList is null) return;

            foreach (var person in TodoList.OrderBy(_ => _.Id))
            {
                TodoQueryable = TodoQueryable.Concat(new[] { person }.AsQueryable());
            }
        }

        private void GetDataAgain()
        {
            Todo = new();
            TodoQueryable = Enumerable.Empty<Todo>().AsQueryable();
            TodoList = GetTodoList();
            ConvertListToQueryable();
        }

        private GridSort<Todo> SortByCompleted = GridSort<Todo>.ByDescending(p => p.Completed);
    }
}
