using System;
using Microsoft.EntityFrameworkCore;
using Plooto.Repositories.EFCore.Models;

namespace Plooto.Repositories.EFCore
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
