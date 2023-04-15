using EmplyeeDetails.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace EmplyeeDetails.Web.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7DLHQPG\\SQLEXPRESS;Database=AjaxPractice;User Id = employe; Password=13579;");
        }
        public DbSet<Country> country { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<Customer> customer { get; set; }

    }
}
