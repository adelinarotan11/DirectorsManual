using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Web.Models;

namespace DirectorsManual.Web.Controllers
{
    public class CartController : Controller
	{
		public PartialViewResult Summary(Cart cart)
		{
			return PartialView(cart);
		}


		private IProductRepository repository;
		private IOrderProcessor orderProcessor;
		private object p;

		public CartController(IProductRepository repo, IOrderProcessor processor)
		{
			repository = repo;
			orderProcessor = processor;
		}

		public CartController(object p)
		{
			this.p = p;
		}

		public RedirectToRouteResult AddToCart(Cart cart, int ID, string returnUrl)//имена параметров соответствуют элементам <input> в HTML-формах, 
																		//созданных в представлении ProductSummary.cshtml.
		{
			TProduct game = repository.Products
				.FirstOrDefault(g => g.ID == ID);

			if (game != null)
			{
				cart.AddItem(game, 1);
			}
			return RedirectToAction("Index", new { returnUrl });//браузеру отправляется инструкция перенаправления HTTP, заставляя браузер запросить новый URL
																//браузер запросит URL, который вызывает метод действия Index() контроллера Cart.
		}

		public RedirectToRouteResult RemoveFromCart(Cart cart, int ID, string returnUrl)
		{
			TProduct game = repository.Products
				.FirstOrDefault(g => g.ID == ID);

			if (game != null)
			{
				cart.RemoveLine(game);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		//public Cart GetCart()
		//{//исп. для создания корзины в виде отдельного сеанса для каждого пользователя

		//	Cart cart = (Cart)Session["Cart"];//извлечение объекта DataSet из памяти сеанса
		//	if (cart == null)
		//	{
		//		cart = new Cart();
		//		Session["Cart"] = cart;//добавить объект в состояние сеанса
		//	}
		//	return cart;
		//}

		public ViewResult Index(Cart cart, string returnUrl)
		{
			return View(new CartIndexViewModel
			{
				Cart = cart,
				ReturnUrl = returnUrl
			});
		}


		public ViewResult Checkout()
		{
			return View(new ShippingDetails());
		}


		[HttpPost]
		public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
		{
			if (cart.Lines.Count() == 0)
			{
				ModelState.AddModelError("", "Извините, ваша корзина пуста!");
			}

			if (ModelState.IsValid)
			{
				orderProcessor.ProcessOrder(cart, shippingDetails);
				cart.Clear();
				return View("Completed");
			}
			else
			{
				return View(shippingDetails);
			}
		}

		//public ViewResult Index(string returnUrl)//визуализирует корзину
		//{
		//	return View(new CartIndexViewModel
		//	{
		//		Cart = GetCart(),
		//		ReturnUrl = returnUrl
		//	});
		//}
	}
}