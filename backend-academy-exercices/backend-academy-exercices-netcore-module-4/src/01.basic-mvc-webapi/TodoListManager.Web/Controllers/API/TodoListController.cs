// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListManager.Businss.Services;
using TodoListManager.Data;
using TodoListManager.Web.Data;
using TodoListManager.Web.Models.Dtos;

namespace TodoListManager.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }


        [Route("task/delete")]
        [HttpPost]
        public void DeleteTask([FromQuery] int taskid)
        {
            _todoListService.DeleteTask(taskid);
        }

        [Route("task/complete")]
        [HttpPost]
        public void CompleteTask([FromQuery] int taskid)
        {
            _todoListService.ToggleCompleteTask(taskid);
        }

        [Route("task")]
        [HttpPost]
        public void CreateTask([FromQuery] int todolistid, [FromBody] CreateTaskDto data)
        {
            _todoListService.CreateTask(todolistid, data.Task, data.Priority);
        }
    }
}
