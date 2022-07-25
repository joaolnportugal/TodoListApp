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
    internal class UnitOfWork : IUnitOfWork
    {
        private TodoListManagerDbContext _context;
        public IGenericRepository<TodoList> todoList;
        public IGenericRepository<TodoListTask> taskItem;


        public UnitOfWork (TodoListManagerDbContext dbContext) 
        {
            _context = dbContext;
        }


        public IGenericRepository<TodoList> TodoListRepo
        {
            get
            {

                if (this.todoList == null)
                {
                    this.todoList = new GenericRepository<TodoList>(_context);
                }
                return todoList;
            }
        }

        public IGenericRepository<TodoListTask> Taskitemrepo
        {
            get
            {
                if (this.taskItem == null)
                {
                    this.taskItem = new GenericRepository<TodoListTask>(_context);

                }
                return taskItem;
            }

        }

        //public IGenericRepository<TodoList> TodoListRepo => throw new NotImplementedException();

        //public IGenericRepository<TodoListTask> Taskitemrepo => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
