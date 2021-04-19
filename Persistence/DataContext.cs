using Microsoft.EntityFrameworkCore;
using WebGameTask.Models;

namespace WebGameTask.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<GameTask> GameTasks { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    }
}
