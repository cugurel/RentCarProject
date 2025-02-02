using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class RentManager : IRentService
	{
		IRentDal _rentDal;

		public RentManager(IRentDal rentDal)
		{
			_rentDal = rentDal;
		}

		public void Add(Rent t)
		{
			_rentDal.AddRent(t);
		}

		public void Delete(Rent t)
		{
			_rentDal.DeleteRent(t);
		}

		public List<Rent> GetAll()
		{
			return _rentDal.GetAll();
		}

		public Rent GetById(int id)
		{
			return _rentDal.GetById(id);
		}

		public void Update(Rent t)
		{
			_rentDal.UpdateRent(t);
		}
	}
}
