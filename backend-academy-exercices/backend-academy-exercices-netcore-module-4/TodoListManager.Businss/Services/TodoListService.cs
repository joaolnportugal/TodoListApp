using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListManager.Data;
using TodoListManager.Data.Models;
using TodoListManager.Data.Models.Shared;
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
        private readonly IGenericRepository<TodoListTask> _taskItemRepository;
      

       

        public TodoListService(IGenericRepository<TodoList> todoListRepository, IGenericRepository<TodoListTask> taskItemReporitory)
        {
            
            _taskItemRepository = taskItemReporitory;
            _todoListRepository = todoListRepository;
        }

        //public TodoList? GetTodoListById(int id)
        //{
        //    return TodoListsProvider.GetTodoListById(id);
        //}


        //public void AddTodoList(TodoList todoList)
        //{
        //    TodoListsProvider.AddTodoList(todoList);
        //}


        //public void DeleteTodoList(int todolistId)
        //{
        //    TodoListsProvider.DeleteTodoList(todolistId);
        //}

        //public void DeleteTask(int todolistId, int taskId)
        //{
        //    TodoListsProvider.DeleteTask(todolistId, taskId);
        //}

        //public void ToggleTaskCompletion(int todolistId, int taskId)
        //{
        //    TodoListsProvider.ToggleTaskCompletion(todolistId, taskId);
        //}

        //public void AddTask(int todolistId, string description, int priority)
        //{
        //    TodoListsProvider.AddTask(todolistId, description, priority);
        //}

        public IEnumerable<TodoList> GetAll() =>
              _todoListRepository.PrepareQuery()
                  .AsNoTracking()
                  .Include(x => x.Tasks)
                  .ToList();

        public void CreateTodoList(TodoList todoList)
        {
            
            _todoListRepository.Add(todoList);
            _todoListRepository.Save();
        }

        public TodoList GetById(int id, bool trackEntity = false)
        {
            var query = _todoListRepository.PrepareQuery();

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return query
                .Include(x => x.Tasks)
                .SingleOrDefault(x => x.Id == id);
        }

        public void UpdateTodoList(TodoList todoList)
        {
            _todoListRepository.Save();
        }

        public void DeleteTodoList(TodoList todoList)
        {
            _todoListRepository.Delete(todoList);
            _todoListRepository.Save();
        }

        public void DeleteTask(int taskId)
        {
            var task = _taskItemRepository.Find(taskId);

            if (task is not null)
            {
                _taskItemRepository.Delete(task);
                _todoListRepository.Save();
            }
        }

        public void ToggleCompleteTask(int TaskId)
        {
            var task = _taskItemRepository.Find(TaskId);
            if (task is not null)
            {
                task.IsComplete = !task.IsComplete;
                _todoListRepository.Save();
            }
        }

        public void CreateTask(int todoListId, string description, int priority)
        {


            var todoList = _todoListRepository.PrepareQuery()
                .Include(x => x.Tasks)
                .SingleOrDefault(x => x.Id == todoListId);

            if (todoList is not null)
            {
                var task = new TodoListTask()
                {
                    Description = description,
                    Priority = (Priority)priority
                };
                todoList.Tasks.Add(task);
                _todoListRepository.Save();
            }
        }


    }
}
