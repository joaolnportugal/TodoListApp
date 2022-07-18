// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListManager.Web.Data;
using TodoListManager.Web.Models.Dtos;

namespace TodoListManager.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        [Route("task/delete")]
        [HttpPost]
        public void DeleteTask([FromQuery] Guid todolistid, [FromQuery] Guid taskid)
        {
            TodoListsProvider.DeleteTask(todolistid, taskid);
        }

        [Route("task/complete")]
        [HttpPost]
        public void CompleteTask([FromQuery] Guid todolistid, [FromQuery] Guid taskid)
        {
            TodoListsProvider.ToggleTaskCompletion(todolistid, taskid);
        }

        [Route("task")]
        [HttpPost]
        public void CreateTask([FromQuery] Guid todolistid, [FromBody] CreateTaskDto data)
        {
            TodoListsProvider.AddTask(todolistid, data.Task, data.Priority);
        }
    }
}
