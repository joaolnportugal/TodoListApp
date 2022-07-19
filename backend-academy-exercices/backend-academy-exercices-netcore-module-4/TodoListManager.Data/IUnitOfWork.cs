// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListManager.Data.Models;
using TodoListManager.Web.Models.Generic_Repo;

namespace TodoListManager.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TodoList> TodoListRepo { get; }
        IGenericRepository<TodoListTask> Taskitemrepo { get; }

        void Save();
    }
}
