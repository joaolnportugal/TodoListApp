// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using TodoListManager.Web.Data;
using TodoListManager.Data.Models;

namespace TodoListManager.Web.Models
{
    public record ListTodoListViewModel
    {
        private IEnumerable<TodoList> _todoLists;
        private TodoList _todoLists1;

        public List<TodoListInfo> TodoLists { get; set; } = new List<TodoListInfo>();

        public ListTodoListViewModel(List<TodoList> todoLists)
        {
            TodoLists = todoLists.Select(t => new TodoListInfo(t)).ToList();
        }

    
    }

    public class TodoListInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskCount { get; set; }
        public string ColorCssClasses { get; set; }

        public TodoListInfo(TodoList todoList)
        {
            Id = todoList.Id;
            Name = todoList.Name;
            Description = todoList.Description;
            TaskCount = todoList.Tasks.Count;
            ColorCssClasses = todoList.Color.GetCssClasses();
        }
    }
}
