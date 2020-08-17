using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Entity;

namespace ToDo.Data.Context
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> ct) : base(ct)
        {

        }
 
        public DbSet<Entity.ToDo> ToDo { get; set; }


    }
}
