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
        /// <summary>
		///  Returns list of Breweries by calling GET request
		/// </summary>
        /// <returns>
        ///  Records of Breweries
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brewery>>> GetBreweries()
        {
            List<Brewery> breweryList = await _openBreweryServices.GetAllAsync();

            return breweryList;
        }

        // GET: api/Breweries/5
        /// <summary>
		///  Fetches Brewery record by id value by calling GET request
		/// </summary>
		/// <param name="id">
		///  Id of Brewery record.
		/// </param>
        /// <returns>
        ///  Record of Brewery
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Brewery>> GetBrewery(string id)
        {
            return await _context.Breweries.FindAsync(id);
        }

        // GET: api/Breweries/city/Miami
        /// <summary>
        ///  Fetches Brewery record by city by calling GET request
        /// </summary>
        /// <param name="city">
        ///  City where Brewery is located
        /// </param>
        /// <returns>
        ///  list of records of Breweries in the city
        /// </returns>
        [HttpGet("city/{city}")]
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
        /// <summary>
        ///  Fetches Brewery record by state by calling GET request
        /// </summary>
        /// <param name="state">
        ///  State or province where Brewery is located
        /// </param>
        /// <returns>
        ///  list of records of Breweries in the state or province
        /// </returns>
        [HttpGet("state/{state}")]
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
        /// <summary>
        ///  Updates Brewery record by calling PUT request
        /// </summary>
        /// <param name="id">
        ///  Id value of Brewery
        /// </param>
        /// <param name="brewery">
        ///  Brewery record with new field values
        /// </param>
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
        /// <summary>
        ///  Adds Brewery record to database by calling POST request
        /// </summary>
        /// <param name="id">
        ///  Id value of Brewery
        /// </param>
        /// <param name="brewery">
        ///  Brewery record with new field values
        /// </param>
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
        /// <summary>
        ///  Deletes Brewery record to database by calling DELETE request
        /// </summary>
        /// <param name="id">
        ///  Id value of Brewery
        /// </param>
        /// <param name="brewery">
        ///  Brewery record with new field values
        /// </param>
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

        /// <summary>
        ///  Checks if brewery exists
        /// </summary>
        /// <param name="id">
        ///  Id value of Brewery
        /// </param>
        /// <returns>
        ///  True if it exists.  False if it doesn't
        /// </returns>
        private bool BreweryExists(string id)
        {
            return _context.Breweries.Any(e => e.ObdbId == id);
        }
    }
}
