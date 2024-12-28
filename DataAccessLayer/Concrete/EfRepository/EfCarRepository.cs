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
    public class EfCarRepository : ICarDal
    {
        public void AddCar(Car car)
        {
            using var c = new Context();
            c.Cars.Add(car);
            c.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            using var c = new Context();
            c.Cars.Remove(car);
            c.SaveChanges();
        }

        public List<Car> GetAll()
        {
            using var c = new Context();
            return c.Cars.ToList();
        }

        public Car GetById(int Id)
        {
            using var c = new Context();
            return c.Cars.Find(Id);
        }

        public void UpdateCar(Car car)
        {
            using var c = new Context();
            c.Cars.Update(car);
            c.SaveChanges();
        }
    }
}
