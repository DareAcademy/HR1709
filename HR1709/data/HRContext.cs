using HR1709.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR1709.data
{
    // 4
    public class HRContext:IdentityDbContext<ApplicationUser>
    {
        IConfiguration config;
        public HRContext(IConfiguration _config)
        {
            config = _config;
        }
        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<WorkingType> WorkingType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("hrConnection"));
            //optionsBuilder.UseSqlServer("data source=localhost;initial catalog=HRDb1709;integrated security=true");

            //1
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
