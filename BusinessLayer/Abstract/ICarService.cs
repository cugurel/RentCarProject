using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;

namespace BusinessLayer.Abstract
{
	public interface ICarService:IGenericService<Car>
	{
		List<CarStyleDto> GetAllCarsWithStyle();
	}
}
