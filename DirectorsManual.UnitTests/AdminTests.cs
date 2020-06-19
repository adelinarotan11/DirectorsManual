using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DirectorsManual.UnitTests
{
	[TestClass]
	public class AdminTests
	{
		[TestMethod]
		public void Index_Contains_All_Games()
		{
			// Организация - создание имитированного хранилища данных
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
			{
				new TProduct { ID = 1, Name_Product = "Игра1"},
				new TProduct { ID = 2, Name_Product = "Игра2"},
				new TProduct { ID = 3, Name_Product = "Игра3"},
				new TProduct { ID = 4, Name_Product = "Игра4"},
				new TProduct { ID = 5, Name_Product = "Игра5"}
			});

			// Организация - создание контроллера
			AdminController controller = new AdminController(mock.Object);

			// Действие
			List<TProduct> result = ((IEnumerable<TProduct>)controller.Index().
				ViewData.Model).ToList();

			// Утверждение
			Assert.AreEqual(result.Count(), 5);
			Assert.AreEqual("Игра1", result[0].Name_Product);
			Assert.AreEqual("Игра2", result[1].Name_Product);
			Assert.AreEqual("Игра3", result[2].Name_Product);
		}



		[TestMethod]
		public void Can_Edit_Game()
		{
			// Организация - создание имитированного хранилища данных
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
			{
				new TProduct { ID = 1, Name_Product = "Игра1"},
				new TProduct { ID = 2, Name_Product = "Игра2"},
				new TProduct { ID = 3, Name_Product = "Игра3"},
				new TProduct { ID = 4, Name_Product = "Игра4"},
				new TProduct { ID = 5, Name_Product = "Игра5"}
			});


			// Организация - создание контроллера
			AdminController controller = new AdminController(mock.Object);

			// Действие
			TProduct game1 = controller.Edit(1).ViewData.Model as TProduct;
			TProduct game2 = controller.Edit(2).ViewData.Model as TProduct;
			TProduct game3 = controller.Edit(3).ViewData.Model as TProduct;

			// Assert
			Assert.AreEqual(1, game1.ID);
			Assert.AreEqual(2, game2.ID);
			Assert.AreEqual(3, game3.ID);
		}

		[TestMethod]
		public void Cannot_Edit_Nonexistent_Game()
		{
			// Организация - создание имитированного хранилища данных
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
			{
				new TProduct { ID = 1, Name_Product = "Игра1"},
				new TProduct { ID = 2, Name_Product = "Игра2"},
				new TProduct { ID = 3, Name_Product = "Игра3"},
				new TProduct { ID = 4, Name_Product = "Игра4"},
				new TProduct { ID = 5, Name_Product = "Игра5"}
			});

			// Организация - создание контроллера
			AdminController controller = new AdminController(mock.Object);

			// Действие
			TProduct result = controller.Edit(6).ViewData.Model as TProduct;

			// Assert
		}


		[TestMethod]
		public void Can_Save_Valid_Changes()
		{
			// Организация - создание имитированного хранилища данных
			Mock<IProductRepository> mock = new Mock<IProductRepository>();

			// Организация - создание контроллера
			AdminController controller = new AdminController(mock.Object);

			// Организация - создание объекта Game
			TProduct prod = new TProduct { Name_Product = "Test" };

			// Действие - попытка сохранения товара
			ActionResult result = controller.Edit(prod);

			// Утверждение - проверка того, что к хранилищу производится обращение
			mock.Verify(m => m.SaveProduct(prod));

			// Утверждение - проверка типа результата метода
			Assert.IsNotInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod]
		public void Cannot_Save_Invalid_Changes()
		{
			// Организация - создание имитированного хранилища данных
			Mock<IProductRepository> mock = new Mock<IProductRepository>();

			// Организация - создание контроллера
			AdminController controller = new AdminController(mock.Object);

			// Организация - создание объекта Game
			TProduct prod = new TProduct { Name_Product = "Test" };

			// Организация - добавление ошибки в состояние модели
			controller.ModelState.AddModelError("error", "error");

			// Действие - попытка сохранения товара
			ActionResult result = controller.Edit(prod);

			// Утверждение - проверка того, что обращение к хранилищу НЕ производится 
			mock.Verify(m => m.SaveProduct(It.IsAny<TProduct>()), Times.Never());

			// Утверждение - проверка типа результата метода
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}


		[TestMethod]
		public void Can_Delete_Valid_Games()
		{
			// Организация - создание объекта Game
			TProduct prod = new TProduct { ID = 2, Name_Product = "Игра2" };

			// Организация - создание имитированного хранилища данных
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
	{
		new TProduct { ID = 1, Name_Product = "Игра1"},
		new TProduct { ID = 2, Name_Product = "Игра2"},
		new TProduct { ID = 3, Name_Product = "Игра3"},
		new TProduct { ID = 4, Name_Product = "Игра4"},
		new TProduct { ID = 5, Name_Product = "Игра5"}
	});

			// Организация - создание контроллера
			AdminController controller = new AdminController(mock.Object);

			// Действие - удаление игры
			controller.Delete(prod.ID);

			// Утверждение - проверка того, что метод удаления в хранилище
			// вызывается для корректного объекта Game
			mock.Verify(m => m.DeleteProduct(prod.ID));
		}
	}
}
