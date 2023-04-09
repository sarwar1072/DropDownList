using Microsoft.EntityFrameworkCore;

namespace CascadingDropDownList.Web.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7DLHQPG\\SQLEXPRESS;Database=WebGentle;User Id = employe; Password=13579;");
        }
        public DbSet<Country> country { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<State> states { get; set; }

    }
}
