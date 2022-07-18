// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace TodoListManager.Data.Models
{
    public class TaskItem : EntityBase
    {

        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool IsComplete { get; set; }
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }


        public TaskItem(string description)
        {
            Description = description;
        }
    }
}
