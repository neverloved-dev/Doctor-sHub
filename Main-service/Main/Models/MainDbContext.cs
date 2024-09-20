using Microsoft.EntityFrameworkCore;

namespace Main.Models
{
    public class MainDbContext:DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext>options):base(options)
        {

        }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
