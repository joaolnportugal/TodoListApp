// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using TodoListManager.Data.Models;
using TodoListManager.Businss.Services;
using TodoListManager.Web.Models;
using TodoListManager.Web.Data;
using TodoListManager.Data;

namespace TodoListManager.Web.Controllers
{
    public class TodoListController : Controller
    {

        private ITodoListService _todoListService;



        public TodoListController()
        {
            _todoListService = new TodoListService(new TodoListContext());
        }
        public IActionResult Index()
        {

            var todoLists = TodoListsProvider.TodoLists.ToList();
            var model = new ListTodoListViewModel(todoLists);
            return View(model);
        }

        public IActionResult New()
        {
            var model = new NewTodoListViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New([FromForm] NewTodoListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var todoList = new TodoList(model.Name)
            {
                Description = model.Description,
                Color = (Color)model.SelectedColor
            };
            _todoListService.AddTodoList(todoList);

            return RedirectToAction("Index");
        }

        public IActionResult View(Guid? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            var todoList = _todoListService.GetTodoListById(id.Value);
            if (todoList is null)
            {
                return RedirectToAction("Index");
            }

            var model = new ViewTodoListViewModel(todoList);
            return View(model);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            var todoList = _todoListService.GetTodoListById(id.Value);
            if (todoList is null)
            {
                return RedirectToAction("Index");
            }

            var model = new EditTodoListViewModel(todoList);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] EditTodoListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var todoList = _todoListService.GetTodoListById(model.Id);
            if (todoList is null)
            {
                return RedirectToAction("index");
            }

            todoList.Name = model.Name;
            todoList.Description = model.Description;
            todoList.Color = (Color)model.SelectedColor;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _todoListService.DeleteTodoList(id);

            return RedirectToAction("Index");
        }
    }
}
