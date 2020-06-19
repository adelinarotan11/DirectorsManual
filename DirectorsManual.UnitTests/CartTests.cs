using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Web.Models;
using DirectorsManual.Web.Controllers;
using Moq;
using DirectorsManual.Domain.Abstract;
using System.Web.Mvc;


namespace DirectorsManual.UnitTests
{
	[TestClass]
	public class CartTests
	{
		[TestMethod]
		public void Can_Add_New_Lines()
		{
			// Организация - создание нескольких тестовых игр
			TProduct game1 = new TProduct { ID = 1, Name_Product = "Игра1" };
			TProduct game2 = new TProduct { ID = 2, Name_Product = "Игра2" };

			// Организация - создание корзины
			Cart cart = new Cart();

			// Действие
			cart.AddItem(game1, 1);
			cart.AddItem(game2, 1);
			List<CartLine> results = cart.Lines.ToList();

			// Утверждение
			Assert.AreEqual(results.Count(), 2);
			Assert.AreEqual(results[0].Product, game1);
			Assert.AreEqual(results[1].Product, game2);
		}

		[TestMethod]
		public void Can_Add_Quantity_For_Existing_Lines()
		{
			// Организация - создание нескольких тестовых игр
			TProduct game1 = new TProduct { ID = 1, Name_Product = "Игра1" };
			TProduct game2 = new TProduct { ID = 2, Name_Product = "Игра2" };

			// Организация - создание корзины
			Cart cart = new Cart();

			// Действие
			cart.AddItem(game1, 1);
			cart.AddItem(game2, 1);
			cart.AddItem(game1, 5);
			List<CartLine> results = cart.Lines.OrderBy(c => c.Product.ID).ToList();

			// Утверждение
			Assert.AreEqual(results.Count(), 2);
			Assert.AreEqual(results[0].Quantity, 6);    // 6 экземпляров добавлено в корзину
			Assert.AreEqual(results[1].Quantity, 1);
		}

		[TestMethod]
		public void Can_Remove_Line()
		{
			// Организация - создание нескольких тестовых игр
			TProduct game1 = new TProduct { ID = 1, Name_Product = "Игра1" };
			TProduct game2 = new TProduct { ID = 2, Name_Product = "Игра2" };
			TProduct game3 = new TProduct { ID = 3, Name_Product = "Игра3" };

			// Организация - создание корзины
			Cart cart = new Cart();

			// Организация - добавление нескольких игр в корзину
			cart.AddItem(game1, 1);
			cart.AddItem(game2, 4);
			cart.AddItem(game3, 2);
			cart.AddItem(game2, 1);

			// Действие
			cart.RemoveLine(game2);

			// Утверждение
			Assert.AreEqual(cart.Lines.Where(c => c.Product == game2).Count(), 0);
			Assert.AreEqual(cart.Lines.Count(), 2);
		}

		[TestMethod]
		public void Calculate_Cart_Total()
		{
			// Организация - создание нескольких тестовых игр
			TProduct game1 = new TProduct { ID = 1, Name_Product = "Игра1", Price = 100 };
			TProduct game2 = new TProduct { ID = 2, Name_Product = "Игра2", Price = 55 };

			// Организация - создание корзины
			Cart cart = new Cart();

			// Действие
			cart.AddItem(game1, 1);
			cart.AddItem(game2, 1);
			cart.AddItem(game1, 5);
			decimal result = cart.ComputeTotalValue();

			// Утверждение
			Assert.AreEqual(result, 655);
		}

		[TestMethod]
		public void Can_Clear_Contents()
		{
			// Организация - создание нескольких тестовых игр
			TProduct game1 = new TProduct { ID = 1, Name_Product = "Игра1", Price = 100 };
			TProduct game2 = new TProduct { ID = 2, Name_Product = "Игра2", Price = 55 };

			// Организация - создание корзины
			Cart cart = new Cart();

			// Действие
			cart.AddItem(game1, 1);
			cart.AddItem(game2, 1);
			cart.AddItem(game1, 5);
			cart.Clear();

			// Утверждение
			Assert.AreEqual(cart.Lines.Count(), 0);
		}


		/// <summary>
		/// Проверяем добавление в корзину
		/// </summary>
		[TestMethod]
		public void Can_Add_To_Cart()
		{
			// Организация - создание имитированного хранилища
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct> {
		new TProduct {ID = 1, Name_Product = "Игра1", Category = "Кат1"},
	}.AsQueryable());

			// Организация - создание корзины
			Cart cart = new Cart();

			// Организация - создание контроллера
			CartController controller = new CartController(mock.Object);

			// Действие - добавить игру в корзину
			controller.AddToCart(cart, 1, null);

			// Утверждение
			Assert.AreEqual(cart.Lines.Count(), 1);
			Assert.AreEqual(cart.Lines.ToList()[0].Product.ID, 1);
		}

		/// <summary>
		/// После добавления игры в корзину, должно быть перенаправление на страницу корзины
		/// </summary>
		[TestMethod]
		public void Adding_Game_To_Cart_Goes_To_Cart_Screen()
		{
			// Организация - создание имитированного хранилища
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new List<TProduct> {
		new TProduct {ID = 1, Name_Product = "Игра1", Category = "Кат1"},
	}.AsQueryable());

			// Организация - создание корзины
			Cart cart = new Cart();

			// Организация - создание контроллера
			CartController controller = new CartController(mock.Object);

			// Действие - добавить игру в корзину
			RedirectToRouteResult result = controller.AddToCart(cart, 2, "myUrl");

			// Утверждение
			Assert.AreEqual(result.RouteValues["action"], "Index");
			Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
		}

		// Проверяем URL
		[TestMethod]
		public void Can_View_Cart_Contents()
		{
			// Организация - создание корзины
			Cart cart = new Cart();

			// Организация - создание контроллера
			CartController target = new CartController(null);

			// Действие - вызов метода действия Index()
			CartIndexViewModel result
				= (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

			// Утверждение
			Assert.AreSame(result.Cart, cart);
			Assert.AreEqual(result.ReturnUrl, "myUrl");
		}
	}


}
