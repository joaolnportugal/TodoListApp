// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using TodoListManager.Businss.Services;
using TodoListManager.Data;
using TodoListManager.Web.Models.Generic_Repo;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TodoListContext>(opts =>
            {
                var connectionString = configuration.GetConnectionString("Default");
                var migrationsAssembly = typeof(TodoListContext).Assembly.GetName().Name;

                opts.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(15), null);
                });
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITodoListService, TodoListService>();


            return services;
        }
    }
}
