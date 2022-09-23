using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
using HotelListing.Models.Country;
using AutoMapper;
using HotelListing.Repository;
using HotelListing.Contracts;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(IMapper mapper, ICountriesRepository countryRepository)
        {
            _mapper = mapper;
            this._countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            //var counties = await _context.Countries.ToListAsync();
            var counties = await _countryRepository.GetAllAsync();

            var record = _mapper.Map<List<GetCountryDto>>(counties);
            return Ok(record);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailCountryDto>> GetCountry(int id)
        {
            //var country = await _context.Countries.FindAsync(id);
            //var country = await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
            var country = await _countryRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<DetailCountryDto>(country);
            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id,UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(updatecountry).State = EntityState.Modified;
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                //await _context.SaveChangesAsync();
              await  _countryRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(UpdateCountryDto createcountry)
        {
            var country = _mapper.Map<Country>(createcountry);

            //_context.Countries.Add(country);
            await _countryRepository.AddAsync(country);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var country = await _context.Countries.FindAsync(id);
            var country = await _countryRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

           await _countryRepository.DeleteAsync(id);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countryRepository.Exists(id);
        }
    }
}
