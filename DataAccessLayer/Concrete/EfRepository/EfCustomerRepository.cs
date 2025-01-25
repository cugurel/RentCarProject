using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EfRepository
{
	public class EfCustomerRepository : ICustomerDal
	{
		public void AddCustomer(Customer customer)
		{
			using var c = new Context();
			c.Customers.Add(customer);
			c.SaveChanges();
		}

		public void DeleteCustomer(Customer customer)
		{
			using var c = new Context();
			c.Customers.Remove(customer);
			c.SaveChanges();
		}

		public List<Customer> GetAll()
		{
			using var c = new Context();
			return c.Customers.ToList();
		}

		public Customer GetById(int Id)
		{
			using var c = new Context();
			return c.Customers.Find(Id);
		}

		public void UpdateCustomer(Customer customer)
		{
			using var c = new Context();
			c.Customers.Update(customer);
			c.SaveChanges();
		}
	}
}
