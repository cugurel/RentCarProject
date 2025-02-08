using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EfRepository;

namespace BusinessLayer.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
            //Customer tablosu için bağımlılık yönetimi
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerDal>().SingleInstance();

            //Car tablosu için bağımlılık yönetimi
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
			builder.RegisterType<EfCarRepository>().As<ICarDal>().SingleInstance();

			//Rent tablosu için bağımlılık yönetimi
			builder.RegisterType<RentManager>().As<IRentService>().SingleInstance();
			builder.RegisterType<EfRentRepository>().As<IRentDal>().SingleInstance();
		}
	}
}
