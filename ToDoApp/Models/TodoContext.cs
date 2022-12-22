using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todoes.Models
{
    public class TodoContext :DbContext
    {
        public TodoContext()
        {

        }
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
