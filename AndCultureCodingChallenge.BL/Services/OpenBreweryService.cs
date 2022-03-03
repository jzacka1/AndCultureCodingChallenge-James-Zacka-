using AndCultureCodingChallenge.BL.Interface;
using AndCultureCodingChallenge.Data.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndCultureCodingChallenge.BL.Services
{
	public class OpenBreweryService: BusinessDbAccess, IDataService<Brewery>, IOpenBreweryService
	{
		private readonly IMemoryCache _memoryCache;

		public OpenBreweryService(OpenBreweryDBContext db, IMemoryCache memoryCache) : base(db)
		{
			_memoryCache = memoryCache;
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
			List<Brewery> list;

			string breweryListKey = "breweryListKey";

			if (_memoryCache.TryGetValue(breweryListKey, out list))
				return list;

			try
			{
				list = Db.Breweries.ToList<Brewery>();

				var cacheOptions = new MemoryCacheEntryOptions()
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(15),
					SlidingExpiration = TimeSpan.FromMinutes(5),
					Priority = CacheItemPriority.High
				};

				_memoryCache.Set(breweryListKey, list, cacheOptions);
			}
			catch (Exception ex) {
				throw;
			}

			return list;
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
			Brewery item;

			string breweryItemKey = "breweryItemKey";

			if (_memoryCache.TryGetValue(breweryItemKey, out item))
				return item;

			try
			{
				item = Db.Breweries.Find(id);

				var cacheOptions = new MemoryCacheEntryOptions()
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(5),
					SlidingExpiration = TimeSpan.FromMinutes(2),
					Priority = CacheItemPriority.High
				};

				_memoryCache.Set(breweryItemKey, item, cacheOptions);
			}
			catch (Exception ex)
			{
				throw;
			}

			return item;
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
