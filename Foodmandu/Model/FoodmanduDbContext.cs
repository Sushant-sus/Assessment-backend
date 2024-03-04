using Microsoft.EntityFrameworkCore;

namespace Foodmandu.Model
{
    public class FoodmanduDbContext:DbContext
    {
        public FoodmanduDbContext(DbContextOptions<FoodmanduDbContext> options) : base(options)
        {
        }
        public DbSet<Layouts> Layouts { get; set; }
        public DbSet<LayoutItems> LayoutItems { get; set; }
    }
}
