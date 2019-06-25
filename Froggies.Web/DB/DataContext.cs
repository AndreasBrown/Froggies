using Froggies.Web.Model.Levels;
using Microsoft.EntityFrameworkCore;

namespace Froggies.Web.DB
{
    public class DataContext : DbContext
    {
        public DbSet<Level> Levels { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // First level.

            modelBuilder.Entity<Level>().HasData(
                new Level() {
                    Id = 1,
                    Cells = new[] 
                        {
                            new [] { Cell.GreenFrog, Cell.None, Cell.Empty, Cell.None, Cell.Empty },
                            new [] { Cell.None, Cell.GreenFrog, Cell.None, Cell.Empty, Cell.None },
                            new [] { Cell.Empty, Cell.None, Cell.GreenFrog, Cell.None, Cell.Empty },
                            new [] { Cell.None, Cell.RedFrog, Cell.None, Cell.Empty, Cell.None },
                            new [] { Cell.Empty, Cell.None, Cell.Empty, Cell.None, Cell.Empty },
                        }  
                    });
        }
    }
}
