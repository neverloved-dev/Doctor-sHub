using Microsoft.EntityFrameworkCore;

namespace Main.Models
{
    public class MainContext:DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
        }
    }
}
