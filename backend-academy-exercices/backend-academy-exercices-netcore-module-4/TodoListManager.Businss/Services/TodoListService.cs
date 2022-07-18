using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListManager.Data;
using TodoListManager.Data.Models;
using TodoListManager.Data.GenericRepo;
using TodoListManager.Web.Models.Generic_Repo;

namespace TodoListManager.Businss.Services
{

    public interface ITodoListService
    {
        IEnumerable<TodoList> GetAll();
        void CreateTodoList(TodoList todoList);
        TodoList GetById(int id, bool trackEntity = false);
        void UpdateTodoList(TodoList todoList);
        void DeleteTodoList(TodoList todoList);
        void DeleteTask(int taskId);
        void ToggleCompleteTask(int TsakId);
        void CreateTask(int todoListId, string description, int priority);

    }

public class TodoListService : ITodoListService
    {

        private readonly IGenericRepository<TodoList> _todoListRepository;
        private readonly IGenericRepository<TaskItem> _taskItemRepository;
        //private readonly IGenericRepository<TodoListContext> _todoListcontext;

        private readonly TodoListContext _todoListContext;

        public TodoListService(TodoListContext todoListContext)
        {
            _todoListContext = todoListContext;
        }

        public TodoList? GetTodoListById(Guid id)
        {
            return TodoListsProvider.GetTodoListById(id);
        }


        public void AddTodoList(TodoList todoList)
        {
            TodoListsProvider.AddTodoList(todoList);
        }


        public void DeleteTodoList(Guid todolistId)
        {
            TodoListsProvider.DeleteTodoList(todolistId);
        }

        public void DeleteTask(Guid todolistId, Guid taskId)
        {
            TodoListsProvider.DeleteTask(todolistId, taskId);
        }

        public void ToggleTaskCompletion(Guid todolistId, Guid taskId)
        {
            TodoListsProvider.ToggleTaskCompletion(todolistId, taskId);
        }

        public void AddTask(Guid todolistId, string description, int priority)
        {
            TodoListsProvider.AddTask(todolistId, description, priority);
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _todoListContext.TodoLists.ToList();
        }

        public void CreateTodoList(TodoList todoList)
        {
            _todoListContext.TodoLists.Add(todoList);
        }

        public TodoList GetById(int id, bool trackEntity = false)
        {
            return _todoListContext.ge;
        }

        public void UpdateTodoList(TodoList todoList)
        {
            _todoListContext.TodoLists.Update(todoList);
        }

        public void DeleteTodoList(TodoList todoList)
        {
            _todoListContext.TodoLists.Remove(todoList);
                    }

        public void DeleteTask(int taskId)
        {
           var task = _todoListContext.TaskItems.Find(taskId);

            if (task is not null)
            {
                _todoListContext.TaskItems.Remove(task);
                _todoListContext.TaskItems.
            }
        }

        public void ToggleCompleteTask(int TsakId)
        {
            throw new NotImplementedException();
        }

        public void CreateTask(int todoListId, string description, int priority)
        {
            throw new NotImplementedException();
        }
    }
}
