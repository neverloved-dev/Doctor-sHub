using Microsoft.EntityFrameworkCore;

namespace Main.Models
{
    public class MainDataContext:DbContext
    {
        public MainDataContext(DbContextOptions<MainDataContext> options) : base(options) 
        {
            
        }
        public DbSet<Prescription> Prescription { get; set; }
    }
}
