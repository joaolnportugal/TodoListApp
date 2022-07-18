// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoListManager.Data.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }

    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
