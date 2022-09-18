using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.Country;

namespace HotelListing.Configration.Mapper
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
        }
    }
}
