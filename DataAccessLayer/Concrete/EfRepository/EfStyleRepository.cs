using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EfRepository
{
	public class EfStyleRepository : IStyleDal
	{
		public void AddStyle(Style style)
		{
			using var c = new Context();
			c.Styles.Add(style);
			c.SaveChanges();
		}

		public void DeleteStyle(Style style)
		{
			using var c = new Context();
			c.Styles.Remove(style);
			c.SaveChanges();
		}

		public List<Style> GetAll()
		{
			using var c = new Context();
			return c.Styles.ToList();
		}

		public Style GetById(int Id)
		{
			using var c = new Context();
			return c.Styles.Find(Id);
		}

		public void UpdateStyle(Style style)
		{
			using var c = new Context();
			c.Styles.Update(style);
			c.SaveChanges();
		}
	}
}
