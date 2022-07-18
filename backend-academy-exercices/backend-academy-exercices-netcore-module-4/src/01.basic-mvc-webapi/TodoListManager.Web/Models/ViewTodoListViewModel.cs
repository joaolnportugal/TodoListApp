// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using TodoListManager.Web.Data;
using TodoListManager.Data.Models;

namespace TodoListManager.Web.Models
{
    public record ViewTodoListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ColorCssClasses { get; set; }
        public List<TaskInfo> Tasks { get; set; }

        public ViewTodoListViewModel(TodoList todoList)
        {
            Id = todoList.Id;
            Name = todoList.Name;
            Description = todoList.Description;
            ColorCssClasses = todoList.Color.GetCssClasses();
            Tasks = todoList.Tasks.Select(t => new TaskInfo(t)).ToList();
        }
    }

    public class TaskInfo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }

        public TaskInfo(TaskItem taskItem)
        {
            Id = taskItem.Id;
            Description = taskItem.Description;
            Priority = (int)taskItem.Priority;
            IsComplete = taskItem.IsComplete;
        }
    }
}
