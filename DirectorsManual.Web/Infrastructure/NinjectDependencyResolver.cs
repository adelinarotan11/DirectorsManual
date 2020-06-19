using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Domain.Concrete;
namespace DirectorsManual.Web.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}
		private void AddBindings()
		{
			kernel.Bind<IProductRepository>().To<EFProductRepository>();

			EmailSettings emailSettings = new EmailSettings
			{
				WriteAsFile = bool.Parse(ConfigurationManager
					.AppSettings["Email.WriteAsFile"] ?? "false")
			};

			kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
				.WithConstructorArgument("settings", emailSettings);
		
		}

		//private void AddBindings()
		//{
		//	// Здесь размещаются привязки
		//	kernel.Bind<IProductRepository>().To<EFProductRepository>();

		//	//		//Создание имитированного хранилища
		//	//		Mock<IProductRepository> mock = new Mock<IProductRepository>();
		//	//		mock.Setup(m => m.Products).Returns(new List<TProduct>
		//	//{
		//	//	new TProduct { Name = "SimCity", Price = 1499 },
		//	//	new TProduct { Name = "TITANFALL", Price=2299 },
		//	//	new TProduct { Name = "Battlefield 4", Price=899.4M }
		//	//});
		//	//		kernel.Bind<IProductRepository>().ToConstant(mock.Object);
		//}
		
	}
}