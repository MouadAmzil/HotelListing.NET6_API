using HotelListing.Models.Hotel;

namespace HotelListing.Models.Country
{
    public class DetailCountryDto : BaseCountryDto
    {
            public int Id { get; set; }
            public List<HotelDto> Hotels { get; set; }
    }
}
