using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public void Add(Car t)
		{
			_carDal.AddCar(t);
		}

		public void Delete(Car t)
		{
			_carDal.DeleteCar(t);
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

        public List<CarStyleDto> GetAllCarsWithStyle()
        {
			return _carDal.GetAllCarsWithStyle();
        }

        public Car GetById(int id)
		{
			return _carDal.GetById(id);
		}

		public void Update(Car t)
		{
			_carDal.UpdateCar(t);
		}
	}
}
