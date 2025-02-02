using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EfRepository
{
	public class EfRentRepository : IRentDal
	{
		public void AddRent(Rent rent)
		{
			using var c = new Context();
			c.Rents.Add(rent);
			c.SaveChanges();
		}

		public void DeleteRent(Rent rent)
		{
			using var c = new Context();
			c.Rents.Remove(rent);
			c.SaveChanges();
		}

		public List<Rent> GetAll()
		{
			using var c = new Context();
			return c.Rents.ToList();
		}

		public Rent GetById(int Id)
		{
			using var c = new Context();
			return c.Rents.Find(Id);
		}

		public void UpdateRent(Rent rent)
		{
			using var c = new Context();
			c.Rents.Update(rent);
			c.SaveChanges();
		}
	}
}
