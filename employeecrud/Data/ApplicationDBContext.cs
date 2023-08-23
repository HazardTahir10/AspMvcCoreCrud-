using employeecrud.Models;
using Microsoft.EntityFrameworkCore;

namespace employeecrud.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Employee> employees { get; set; }
    }
}
