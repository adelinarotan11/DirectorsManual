using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Entities;
using DirectorsManual.WebUI.Controllers;
using DirectorsManual.Web.Models;
using DirectorsManual.Web.HtmlHelpers;
using DirectorsManual.Web.Controllers;

namespace DirectorsManual.UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Can_Paginate()
		{
			// Организация (arrange)
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
			{
				new TProduct { ID = 1, Name_Product = "Игра1"},
				new TProduct { ID = 2, Name_Product = "Игра2"},
				new TProduct { ID = 3, Name_Product = "Игра3"},
				new TProduct { ID = 4, Name_Product = "Игра4"},
				new TProduct { ID = 5, Name_Product = "Игра5"}
			});
			ProductController controller = new ProductController(mock.Object);
			controller.pageSize = 3;

			// Действие (act)
			//	IEnumerable<TProduct> result = (IEnumerable<TProduct>)controller.List(2).Model;
			ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;


			// Утверждение (assert)
			//List<TProduct> games = result.ToList();
			List<TProduct> games = result.Products.ToList();
			Assert.IsTrue(games.Count == 2);
			Assert.AreEqual(games[0].Name_Product, "Игра4");
			Assert.AreEqual(games[1].Name_Product, "Игра5");
		}


		[TestMethod]
		public void Can_Generate_Page_Links()
		{

			// Организация - определение вспомогательного метода HTML - это необходимо
			// для применения расширяющего метода
			HtmlHelper myHelper = null;

			// Организация - создание объекта PagingInfo
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 28,
				ItemsPerPage = 10
			};

			// Организация - настройка делегата с помощью лямбда-выражения
			Func<int, string> pageUrlDelegate = i => "Page" + i;

			// Действие
			MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

			// Утверждение
			Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
				+ @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
				+ @"<a class=""btn btn-default"" href=""Page3"">3</a>",
				result.ToString());
		}


		[TestMethod]
		public void Can_Send_Pagination_View_Model()
		{
			// Организация (arrange)
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
	{
		new TProduct { ID = 1, Name_Product = "Игра1"},
		new TProduct { ID = 2, Name_Product = "Игра2"},
		new TProduct { ID = 3, Name_Product = "Игра3"},
		new TProduct { ID = 4, Name_Product = "Игра4"},
		new TProduct { ID = 5, Name_Product = "Игра5"}
	});
			ProductController controller = new ProductController(mock.Object);
			controller.pageSize = 3;

			// Act
			ProductsListViewModel result
				= (ProductsListViewModel)controller.List(null, 2).Model;

			// Assert
			PagingInfo pageInfo = result.PagingInfo;
			Assert.AreEqual(pageInfo.CurrentPage, 2);
			Assert.AreEqual(pageInfo.ItemsPerPage, 3);
			Assert.AreEqual(pageInfo.TotalItems, 5);
			Assert.AreEqual(pageInfo.TotalPages, 2);
		}


		[TestMethod]
		public void Can_Filter_Games()
		{
			// Организация (arrange)
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
	{
		new TProduct { ID = 1, Name_Product = "Игра1", Category="Cat1"},
		new TProduct { ID = 2, Name_Product = "Игра2", Category="Cat2"},
		new TProduct { ID = 3, Name_Product = "Игра3", Category="Cat1"},
		new TProduct { ID = 4, Name_Product = "Игра4", Category="Cat2"},
		new TProduct { ID = 5, Name_Product = "Игра5", Category="Cat3"}
	});
			ProductController controller = new ProductController(mock.Object);
			controller.pageSize = 3;

			// Action
			List<TProduct> result = ((ProductsListViewModel)controller.List("Cat2", 1).Model)
				.Products.ToList();

			// Assert
			Assert.AreEqual(result.Count(), 2);
			Assert.IsTrue(result[0].Name_Product == "Игра2" && result[0].Category == "Cat2");
			Assert.IsTrue(result[1].Name_Product == "Игра4" && result[1].Category == "Cat2");
		}



		[TestMethod]
		public void Can_Create_Categories()
		{
			// Организация - создание имитированного хранилища
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct> {
		new TProduct { ID = 1, Name_Product = "Игра1", Category="Симулятор"},
		new TProduct { ID = 2, Name_Product = "Игра2", Category="Симулятор"},
		new TProduct { ID = 3, Name_Product = "Игра3", Category="Шутер"},
		new TProduct { ID = 4, Name_Product = "Игра4", Category="RPG"},
	});

			// Организация - создание контроллера
			NavController target = new NavController(mock.Object);

			// Действие - получение набора категорий
			List<string> results = ((IEnumerable<string>)target.Menu().Model).ToList();

			// Утверждение
			Assert.AreEqual(results.Count(), 3);
			Assert.AreEqual(results[0], "RPG");
			Assert.AreEqual(results[1], "Симулятор");
			Assert.AreEqual(results[2], "Шутер");
		}


		[TestMethod]
		public void Indicates_Selected_Category()
		{
			// Организация - создание имитированного хранилища
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new TProduct[] {
		new TProduct { ID = 1, Name_Product = "Игра1", Category="Симулятор"},
		new TProduct { ID = 2, Name_Product = "Игра2", Category="Шутер"}
	});

			// Организация - создание контроллера
			NavController target = new NavController(mock.Object);

			// Организация - определение выбранной категории
			string categoryToSelect = "Шутер";

			// Действие
			string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

			// Утверждение
			Assert.AreEqual(categoryToSelect, result);
		}


		[TestMethod]
		public void Generate_Category_Specific_Game_Count()
		{
			/// Организация (arrange)
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct>
	{
		new TProduct { ID = 1, Name_Product = "Игра1", Category="Cat1"},
		new TProduct { ID = 2, Name_Product = "Игра2", Category="Cat2"},
		new TProduct { ID = 3, Name_Product = "Игра3", Category="Cat1"},
		new TProduct { ID = 4, Name_Product = "Игра4", Category="Cat2"},
		new TProduct { ID = 5, Name_Product = "Игра5", Category="Cat3"}
	});
			ProductController controller = new ProductController(mock.Object);
			controller.pageSize = 3;

			// Действие - тестирование счетчиков товаров для различных категорий
			int res1 = ((ProductsListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
			int res2 = ((ProductsListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
			int res3 = ((ProductsListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
			int resAll = ((ProductsListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

			// Утверждение
			Assert.AreEqual(res1, 2);
			Assert.AreEqual(res2, 2);
			Assert.AreEqual(res3, 1);
			Assert.AreEqual(resAll, 5);
		}

		[TestMethod]
		public void Cannot_Checkout_Empty_Cart()//позволяет проверить невозможность перехода к оплате при пустой корзине
		{
			// Организация - создание имитированного обработчика заказов
			Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

			// Организация - создание пустой корзины
			Cart cart = new Cart();

			// Организация - создание деталей о доставке
			ShippingDetails shippingDetails = new ShippingDetails();

			// Организация - создание контроллера
			CartController controller = new CartController(null, mock.Object);

			// Действие
			ViewResult result = controller.Checkout(cart, shippingDetails);

			// Утверждение — проверка, что заказ не был передан обработчику 
			mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
				Times.Never());

			// Утверждение — проверка, что метод вернул стандартное представление 
			Assert.AreEqual("", result.ViewName);

			// Утверждение - проверка, что-представлению передана неверная модель
			Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
		}


		[TestMethod]
		public void Cannot_Checkout_Invalid_ShippingDetails()
		{
			// Организация - создание имитированного обработчика заказов
			Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

			// Организация — создание корзины с элементом
			Cart cart = new Cart();
			cart.AddItem(new TProduct(), 1);

			// Организация — создание контроллера
			CartController controller = new CartController(null, mock.Object);

			// Организация — добавление ошибки в модель
			controller.ModelState.AddModelError("error", "error");

			// Действие - попытка перехода к оплате
			ViewResult result = controller.Checkout(cart, new ShippingDetails());

			// Утверждение - проверка, что заказ не передается обработчику
			mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
				Times.Never());

			// Утверждение - проверка, что метод вернул стандартное представление
			Assert.AreEqual("", result.ViewName);

			// Утверждение - проверка, что-представлению передана неверная модель
			Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
		}

		[TestMethod]
		public void Can_Checkout_And_Submit_Order()
		{
			// Организация - создание имитированного обработчика заказов
			Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

			// Организация — создание корзины с элементом
			Cart cart = new Cart();
			cart.AddItem(new TProduct(), 1);

			// Организация — создание контроллера
			CartController controller = new CartController(null, mock.Object);

			// Действие - попытка перехода к оплате
			ViewResult result = controller.Checkout(cart, new ShippingDetails());

			// Утверждение - проверка, что заказ передан обработчику
			mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
				Times.Once());

			// Утверждение - проверка, что метод возвращает представление 
			Assert.AreEqual("Completed", result.ViewName);

			// Утверждение - проверка, что представлению передается допустимая модель
			Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
		}
	}
}