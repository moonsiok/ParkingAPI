using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Parking> parkings { get; set; }
        public DbSet<Number> Number { get; set; }

    }

   

}
 