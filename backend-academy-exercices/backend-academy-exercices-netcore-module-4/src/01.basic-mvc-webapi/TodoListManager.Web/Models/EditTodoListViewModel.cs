// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoListManager.Data.Models;
using TodoListManager.Data.Models.Shared;

namespace TodoListManager.Web.Models
{
    public record EditTodoListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name", Prompt = "Todo list name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a name for the todo list")]
        public string? Name { get; set; }
        [Display(Name = "Description", Prompt = "Todo list description")]
        public string? Description { get; set; }

        public int SelectedColor { get; set; }
        public List<TodoListColor> AvailableColors { get; set; }
        public EditTodoListViewModel TodoList { get; internal set; }

        public EditTodoListViewModel()
        {
            AvailableColors = Enum.GetValues<Color>().Select(c => new TodoListColor(c)).ToList();
        }

        public EditTodoListViewModel(TodoList todoList)
            : this()
        {
            Id = todoList.Id;
            Name = todoList.Name;
            Description = todoList.Description;
            SelectedColor = (int)todoList.Color;
        }

        public record TodoListColor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CssClassName { get; set; }

            public TodoListColor(Color color)
            {
                Id = (int)color;
                Name = color.ToString();
                CssClassName = color switch
                {
                    Color.DarkBlue => "btn-outline-primary",
                    Color.DarkGray => "btn-outline-secondary",
                    Color.Green => "btn-outline-success",
                    Color.Red => "btn-outline-danger",
                    Color.Yellow => "btn-outline-warning",
                    Color.LightBlue => "btn-outline-info",
                    Color.Black => "btn-outline-dark",
                    Color.White => "btn-outline-white",
                    _ => "btn-outline-primary"
                };
            }
        }
    }
}
