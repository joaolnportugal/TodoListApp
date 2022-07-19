// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace TodoListManager.Data.Models
{
    public class TodoList : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public ICollection<TodoListTask> _tasks { get; set; }

        public TodoList(string name)
        {
            Name = name;
            _tasks = new List<TodoListTask>();
        }

        public void AddTask(string description, int priority)
        {
            _tasks.Add(new TodoListTask(description)
            {
                Priority = (Priority)priority
            });
        }

        public void RemoveTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.Id == taskId);
            if (task is not null)
            {
                _tasks.Remove(task);
            }
        }

        public void ToggleTaskCompletion(int taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.Id == taskId);
            if (task is not null)
            {
                task.IsComplete = !task.IsComplete;
            }
        }
    }
}
