using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
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

        public List<CarStyleDto> GetAllCarsWithStyle()
        {
            using var x = new Context();
            var result = (from c in x.Cars
                          join st in x.Styles on c.Style equals st.Type
                          select new CarStyleDto
                          {
                              Id = c.Id,
                              Brand = c.Brand,
                              Model = c.Model,
                              TypeName = st.TypeName,
                              Price = c.Price,
                              Currency = c.Currency,
                              RevisionDate = c.RevisionDate,
                          });

            return result.ToList();
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
