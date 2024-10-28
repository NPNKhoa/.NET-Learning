using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Duyen"));

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            base.OnModelCreating(optionsBuilder);
            optionsBuilder.Entity<BookAuthor>()
                .HasKey(p => new { p.author_id, p.book_id });

            optionsBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Author)
                .WithMany(p => p.BookAuthors)
                .HasForeignKey(p => p.author_id);

            optionsBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Book)
                .WithMany(p => p.BookAuthors)
                .HasForeignKey(p => p.book_id);

            List<Role> roles = new List<Role>()
            {
                new Role() {
                   role_id = 1,
                   role_desc="admin"
                },
                new Role() {
                   role_id = 2,
                   role_desc="user"
                }
            };

            optionsBuilder.Entity<Role>()
                .HasData(roles);
        }

        public void SeedAdminAccount()
        {
            Database.Migrate();

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string adminEmail = configuration["AdminAccount:Email"];
            string adminPassword = configuration["AdminAccount:Password"];

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminPassword);

            if (!Users.Any(u => u.email_address == adminEmail))
            {
                var adminRole = Roles.FirstOrDefault(r => r.role_desc == "admin");
                if (adminRole != null)
                {
                    Users.Add(new User
                    {
                        email_address = adminEmail,
                        password = hashedPassword,
                        role_id = adminRole.role_id,
                        hire_date = DateTime.Now
                    });
                    SaveChanges();
                }
            }
        }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}

