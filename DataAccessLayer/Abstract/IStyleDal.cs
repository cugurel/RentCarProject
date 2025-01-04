using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IStyleDal
	{
		void AddStyle(Style style);
		void UpdateStyle(Style style);
		void DeleteStyle(Style style);
		Style GetById(int Id);
		List<Style> GetAll();
	}
}
