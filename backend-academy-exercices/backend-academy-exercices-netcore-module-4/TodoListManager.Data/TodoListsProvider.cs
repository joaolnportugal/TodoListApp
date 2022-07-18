// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using TodoListManager.Data.Models;

namespace TodoListManager.Data
{
    public static class TodoListsProvider
    {
        private static readonly List<TodoList> s_todoLists = new();
        public static IReadOnlyCollection<TodoList> TodoLists => s_todoLists;

        public static void Initialize()
        {
            var todoList = new TodoList("Bliss Academy");
            todoList.AddTask("Learn C#", 2);
            todoList.AddTask("Learn MVC & Web API", 2);
            todoList.AddTask("Enjoy myself", 3);
            s_todoLists.Add(todoList);

            todoList = new TodoList("Groceries");
            todoList.AddTask("Coffee", 2);
            todoList.AddTask("Rubber Duck", 3);
            todoList.AddTask("Beer", 1);
            s_todoLists.Add(todoList);
        }

        public static TodoList? GetTodoListById(Guid id)
            => s_todoLists.FirstOrDefault(x => x.Id == id);

        public static void AddTodoList(TodoList todoList)
            => s_todoLists.Add(todoList);

        public static void DeleteTodoList(Guid todolistId)
        {
            var todoList = GetTodoListById(todolistId);
            if (todoList is not null)
            {
                s_todoLists.Remove(todoList);
            }
        }

        public static void DeleteTask(Guid todolistId, Guid taskId)
        {
            var todoList = GetTodoListById(todolistId);
            if (todoList is not null)
            {
                todoList.RemoveTask(taskId);
            }
        }

        public static void ToggleTaskCompletion(Guid todolistId, Guid taskId)
        {
            var todoList = GetTodoListById(todolistId);
            if (todoList is not null)
            {
                todoList.ToggleTaskCompletion(taskId);
            }
        }

        public static void AddTask(Guid todolistId, string description, int priority)
        {
            var todoList = GetTodoListById(todolistId);
            if (todoList is not null)
            {
                todoList.AddTask(description, priority);
            }
        }
    }
}
