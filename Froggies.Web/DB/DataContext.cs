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
    }
}
