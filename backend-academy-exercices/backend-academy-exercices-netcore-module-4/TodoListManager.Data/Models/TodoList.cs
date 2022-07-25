// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListManager.Data.Models.Shared;

namespace TodoListManager.Data.Models
{
    public class TodoList : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public ICollection<TodoListTask> Tasks { get; set; }
    }
    public class TodoListConfiguration : EntityBaseConfiguration<TodoList>
    {
        public override void Configure(EntityTypeBuilder<TodoList> builder)
        {
            base.Configure(builder);

            builder.ToTable("TodoList");

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.Property(x => x.Color)
                .HasDefaultValue(Color.DarkBlue)
                .IsRequired();
        }
    }
}
