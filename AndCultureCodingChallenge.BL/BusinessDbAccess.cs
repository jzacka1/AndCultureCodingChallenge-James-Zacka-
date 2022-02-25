using AndCultureCodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndCultureCodingChallenge.BL
{
	public abstract class BusinessDbAccess : IDisposable
	{
		protected readonly OpenBreweryDBContext Db;

		public BusinessDbAccess(OpenBreweryDBContext db)
		{
			this.Db = db;
		}

		public void Dispose()
		{
			this.Db.Dispose();
			//GC.SuppressFinalize(this);
		}
	}
}
