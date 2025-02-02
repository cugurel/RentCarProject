using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IRentDal
	{
		void AddRent(Rent rent);
		void UpdateRent(Rent rent);
		void DeleteRent(Rent rent);
		Rent GetById(int Id);
		List<Rent> GetAll();
	}
}
