using Microsoft.EntityFrameworkCore;

namespace Main.Models
{
    public class MainContext:DbContext
    {
        public DbSet<Prescription> Prescriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
        }
    }
}
