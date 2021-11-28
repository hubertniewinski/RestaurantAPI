using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=true";

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(r => r.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
              .Property(r => r.Street)
              .IsRequired()
              .HasMaxLength(50);

            modelBuilder.Entity<Restaurant>()
                .HasData(
                new ()
                {
                    Id = 1,
                    Name = "KFC",
                    Category = "Fast Food",
                    Description =
                        "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    AddressId = 1
                },
                new ()
                {
                    Id = 2,
                    Name = "McDonald Szewska",
                    Category = "Fast Food",
                    Description =
                        "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    AddressId = 2
                });

            modelBuilder.Entity<Dish>()
                .HasData(
                    new ()
                    {
                        Id = 1,
                        Name = "Nashville Hot Chicken",
                        Price = 10.30M,
                        RestaurantId = 1
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "Chicken Nuggets",
                        Price = 5.30M,
                        RestaurantId = 1
                    }
                );

            modelBuilder.Entity<Address>()
                .HasData(
                     new ()
                     {
                         Id = 1,
                         City = "Kraków",
                         Street = "Długa 5",
                         PostalCode = "30-001"
                     },
                    new ()
                    {
                        Id = 2,
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-001"
                    }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
