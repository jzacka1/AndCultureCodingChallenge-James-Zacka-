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

		public void Add(Brewery item)
		{
			Db.Add(item);
		}

		public void DeleteById(int id)
		{
			Brewery brewery = GetById(id);
			Db.Remove(brewery);
		}

		public List<Brewery> GetAll()
		{
			return Db.Breweries.ToList<Brewery>();
		}

		public async Task<List<Brewery>> GetAllAsync()
		{
			return await Task.Run(() =>
				GetAll()
			);
		}

		public List<Brewery> GetByCity(string city)
		{
			return Db.Breweries.Where(c => c.City == city).ToList<Brewery>();
		}

		public async Task<List<Brewery>> GetByCityAsync(string city)
		{
			return await Task.Run(() =>
				GetByCity(city)
			);
		}

		public Brewery GetById(int id)
		{
			return Db.Breweries.Find(id);
		}

		public List<Brewery> GetByState(string state)
		{
			return Db.Breweries.Where(c => c.State == state).ToList<Brewery>();
		}

		public async Task<List<Brewery>> GetByStateAsync(string state)
		{
			return await Task.Run(() =>
				GetByState(state)
			);
		}
	}
}
