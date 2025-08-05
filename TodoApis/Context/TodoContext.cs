using Microsoft.EntityFrameworkCore;
using TodoApis.Model;
namespace TodoApis.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<TodoTask> Tasks { get; set; }
    }
}
