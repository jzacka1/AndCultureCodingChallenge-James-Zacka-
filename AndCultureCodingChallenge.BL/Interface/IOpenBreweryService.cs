//using AndCultureCodingChallenge.Data.Models;
using AndCultureCodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndCultureCodingChallenge.BL.Interface
{
	public interface IOpenBreweryService
	{
		List<Brewery> GetAll();
		Task<List<Brewery>> GetAllAsync();
		List<Brewery> GetByCity(string city);
		Task<List<Brewery>> GetByCityAsync(string city);
		List<Brewery> GetByState(string state);
		Task<List<Brewery>> GetByStateAsync(string state);
	}
}
