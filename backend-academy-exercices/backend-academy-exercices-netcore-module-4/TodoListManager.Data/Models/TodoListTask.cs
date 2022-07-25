// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListManager.Data.Models.Shared;

namespace TodoListManager.Data.Models
{
    public class TodoListTask : EntityBase
    {
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool IsComplete { get; set; }
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }

    public class TodoListTaskConfiguration : EntityBaseConfiguration<TodoListTask>
    {
        public override void Configure(EntityTypeBuilder<TodoListTask> builder)
        {
            base.Configure(builder);

            builder.ToTable("TodoListTask");

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Priority)
                .HasDefaultValue(Priority.Normal)
                .IsRequired();

            builder.Property(x => x.IsComplete)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.TodoList)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TodoListId);
        }
    }
}
