using cascadedropdown.Models;
using Microsoft.EntityFrameworkCore;

namespace cascadedropdown.Data
{
    public class AppDBContext : DbContext
    {
       public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }

    }
}
