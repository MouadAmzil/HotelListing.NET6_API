using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class HotelListingDbcontext : DbContext
    {
        public HotelListingDbcontext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = 1,
                        Name = "Morocco",
                        ShortName = "MAR"
                    },
                    new Country
                    {
                        Id = 2,
                        Name = "French",
                        ShortName = "FRA"
                    }
                    );
                modelBuilder.Entity<Hotel>().HasData(
                    new Hotel
                    {
                        Id = 1,
                        Name = "Ahlame",
                        Address = "Center Agdal, Av. Inaouin, Rabat 10000",
                        CountryId = 1,
                        Rating = 4.3
                    },
                     new Hotel
                     {
                         Id = 2,
                         Name = "Mazagan",
                         Address = "Route côtière, Sidi Bouzid 24000",
                         CountryId = 1,
                         Rating = 4.7
                     },
                      new Hotel
                      {
                          Id = 3,
                          Name = "Aour Eiffel Arrondissement",
                          Address = "78 Rue Blomet, 75015 Paris, France",
                          CountryId = 2,
                          Rating = 3.9
                      }
                    );
            }
        }
    }
}
