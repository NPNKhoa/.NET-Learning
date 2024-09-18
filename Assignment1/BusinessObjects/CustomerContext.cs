using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configurationRoot = configuration.Build();
            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Username = "Hoa",
                    Password = "1",
                    Fullname = "Hoa Hoa",
                    Gender = "Female",
                    Birthday = new DateTime(2020, 9, 9),
                    Address = "CT"
                },
                new Customer
                {
                    Username = "Lan",
                    Password = "2",
                    Fullname = "Lan Lan",
                    Gender = "Female",
                    Birthday = new DateTime(2004, 5, 6),
                    Address = "HCM"
                },
                new Customer
                {
                    Username = "Nam",
                    Password = "3",
                    Fullname = "Nam Nam",
                    Gender = "Male",
                    Birthday = new DateTime(2000, 3, 19),
                    Address = "HN"
                },
                new Customer
                {
                    Username = "Tuan",
                    Password = "4",
                    Fullname = "Tuan Tuan",
                    Gender = "Male",
                    Birthday = new DateTime(2009, 9, 29),
                    Address = "CT"
                },
                new Customer
                {
                    Username = "Dung",
                    Password = "5",
                    Fullname = "Dung Dung",
                    Gender = "Male",
                    Birthday = new DateTime(2008, 4, 23),
                    Address = "HCM"
                }
                );

        }
    }
}
