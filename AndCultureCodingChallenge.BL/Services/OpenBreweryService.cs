using AndCultureCodingChallenge.BL.Interface;
using AndCultureCodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndCultureCodingChallenge.BL.Services
{
	public class OpenBreweryService: BusinessDbAccess, IDataService<Brewery>, IOpenBreweryService
	{
		public OpenBreweryService(OpenBreweryDBContext db) : base(db)
		{

		}

		/// <summary>
		///  Adds Brewery record to database
		/// </summary>
		/// <param name="item">
		///  item of typeBrewery
		/// </param>
		public void Add(Brewery item)
		{
			Db.Add(item);
		}

		/// <summary>
		///  Deletes Brewery record by id value
		/// </summary>
		/// <param name="id">
		///  Id of Brewery record.
		/// </param>
		public void DeleteById(int id)
		{
			Brewery brewery = GetById(id);
			Db.Remove(brewery);
		}

		/// <summary>
		///  Fetches all records of breweries
		/// </summary>
		/// <returns>
		///  List of items of type Brewery
		/// </returns>
		public List<Brewery> GetAll()
		{
			return Db.Breweries.ToList<Brewery>();
		}

		/// <summary>
		///  Fetches all records of breweries asynchrounously
		/// </summary>
		/// <returns>
		///  List of items of type Brewery
		/// </returns>
		public async Task<List<Brewery>> GetAllAsync()
		{
			return await Task.Run(() =>
				GetAll()
			);
		}

		/// <summary>
		///  Fetches all records of breweries by city.
		/// </summary>
		/// <param name="city">
		///  City where the breweries are located.
		/// </param>
		/// <returns>
		///  List of items of type Brewery.
		/// </returns>
		public List<Brewery> GetByCity(string city)
		{
			return Db.Breweries.Where(c => c.City == city).ToList<Brewery>();
		}

		/// <summary>
		///  Fetches all records of breweries by city asynchrounously
		/// </summary>
		/// <param name="city">
		///  City where the breweries are located.
		/// </param>
		/// <returns>
		///  List of items of type Brewery.
		/// </returns>
		public async Task<List<Brewery>> GetByCityAsync(string city)
		{
			return await Task.Run(() =>
				GetByCity(city)
			);
		}

		/// <summary>
		///  Fetches a brewery record by id.
		/// </summary>
		/// <param name="id">
		///  Id value of brewery
		/// </param>
		/// <returns>
		///  Record of type Brewery.
		/// </returns>
		public Brewery GetById(int id)
		{
			return Db.Breweries.Find(id);
		}

		/// <summary>
		///  Fetches a brewery record by state.
		/// </summary>
		/// <param name="state">
		///  State where the Breweries are located.
		/// </param>
		/// <returns>
		///  List of records of type Brewery.
		/// </returns>
		public List<Brewery> GetByState(string state)
		{
			return Db.Breweries.Where(c => c.State == state).ToList<Brewery>();
		}

		/// <summary>
		///  Fetches a brewery record by state asynchrounously.
		/// </summary>
		/// <param name="state">
		///  State where the Breweries are located.
		/// </param>
		/// <returns>
		///  List of records of type Brewery.
		/// </returns>
		public async Task<List<Brewery>> GetByStateAsync(string state)
		{
			return await Task.Run(() =>
				GetByState(state)
			);
		}
	}
}
