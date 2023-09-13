global using Microsoft.EntityFrameworkCore;

namespace SuperHero.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {

        }
        public DbSet<SuperHeroModel> SuperHeroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //DESKTOP - K2L42P3\MSSQLSERVER01
            //.\\SQLExpress
            optionsBuilder.UseSqlServer("Server=DESKTOP-K2L42P3\\MSSQLSERVER01;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true");
        }

     
    }
}
