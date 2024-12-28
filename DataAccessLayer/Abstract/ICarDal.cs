using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal
    {
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        Car GetById(int Id);
        List<Car> GetAll();
    }
}
