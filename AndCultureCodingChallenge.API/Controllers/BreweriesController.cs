#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndCultureCodingChallenge.Data.Models;
using AndCultureCodingChallenge.BL.Services;
using AndCultureCodingChallenge.BL.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace AndCultureCodingChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly OpenBreweryDBContext _context;
        private readonly IOpenBreweryService _openBreweryServices;
        private readonly IMemoryCache _memoryCache;
        private readonly string breweryKey = "breweryKey";

        public BreweriesController(OpenBreweryDBContext context, 
                                    IOpenBreweryService openBreweryServices,
                                    IMemoryCache memoryCache)
        {
            _context = context;
            _openBreweryServices = openBreweryServices;
            _memoryCache = memoryCache;       
        }

        // GET: api/Breweries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brewery>>> GetBreweries()
        {
            List<Brewery> breweryList = null;

            // If found in cache, return cached data
            if (_memoryCache.TryGetValue(breweryKey, out breweryList)){
                return Ok(breweryList);
			}

            // If not found, then calculate response
            breweryList = await _context.Breweries.ToListAsync();

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(30),
                Priority = CacheItemPriority.High
            };

            // Set object in cache
            _memoryCache.Set(breweryKey, breweryList, cacheOptions);

            return breweryList;
        }

        // GET: api/Breweries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brewery>> GetBrewery(string id)
        {
            Brewery brewery = null;

            // If found in cache, return cached data
            if (_memoryCache.TryGetValue(breweryKey, out brewery))
            {
                return Ok(brewery);
            }

            brewery = await _context.Breweries.FindAsync(id);

            if (brewery == null)
            {
                return NotFound();
            }

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(30),
                Priority = CacheItemPriority.High
            };

            // Set object in cache
            _memoryCache.Set(breweryKey, brewery, cacheOptions);

            return brewery;
        }

		// GET: api/Breweries/city/Miami
		[HttpGet("city/{city}")]
		//[Route("GetBreweryByCity/{city}")]
		public async Task<ActionResult<List<Brewery>>> GetBreweryByCity(string city)
        {
            var brewery = await _openBreweryServices.GetByCityAsync(city);

            if (brewery == null)
            {
                return NotFound();
            }

            return brewery;
        }

        // GET: api/Breweries/state/Florida
        [HttpGet("state/{state}")]
        //[Route("GetBreweryByCity/{city}")]
        public async Task<ActionResult<List<Brewery>>> GetBreweryByState(string state)
        {
            var brewery = await _openBreweryServices.GetByStateAsync(state);

            if (brewery == null)
            {
                return NotFound();
            }

            return brewery;
        }

        // PUT: api/Breweries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewery(string id, Brewery brewery)
        {
            if (id != brewery.ObdbId)
            {
                return BadRequest();
            }

            _context.Entry(brewery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreweryExists(id))
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

        // POST: api/Breweries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brewery>> PostBrewery(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BreweryExists(brewery.ObdbId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBrewery", new { id = brewery.ObdbId }, brewery);
        }

        // DELETE: api/Breweries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewery(string id)
        {
            var brewery = await _context.Breweries.FindAsync(id);
            if (brewery == null)
            {
                return NotFound();
            }

            _context.Breweries.Remove(brewery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreweryExists(string id)
        {
            return _context.Breweries.Any(e => e.ObdbId == id);
        }
    }
}
