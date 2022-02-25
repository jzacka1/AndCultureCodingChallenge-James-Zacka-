using AndCultureCodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndCultureCodingChallenge.BL.Services
{
	public interface IDataService<T>
	{
		//CRUD Methods
		void Add(T item);
		void DeleteById(int id);

		//Fetch all records from database
		List<T> GetAll();
		Task<List<T>> GetAllAsync();

		//Fetch records by field
		T GetById(int id);
	}
}
