using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface ICustomerDal
	{
		void AddCustomer(Customer customer);
		void UpdateCustomer(Customer customer);
		void DeleteCustomer(Customer customer);
		Customer GetById(int Id);
		List<Customer> GetAll();
	}
}
