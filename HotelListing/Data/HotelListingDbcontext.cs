using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class HotelListingDbcontext : DbContext
    {
        public HotelListingDbcontext(DbContextOptions option) : base(option)
        {
        } 

    }
}
