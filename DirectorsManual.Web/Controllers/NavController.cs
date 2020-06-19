using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Entities;

namespace DirectorsManual.Web.Controllers
{
    public class NavController : Controller
    {
		private IProductRepository repository;

		public NavController(IProductRepository repo)
		{
			repository = repo;
		}

		//public PartialViewResult Menu(string category = null, bool horizontalNav = false)
		//{
		//	ViewBag.SelectedCategory = category;
		//	IEnumerable<string> categories = repository.Products
		//		.Select(prod => prod.Category)
		//		.Distinct()
		//		.OrderBy(x => x);
		//	string viewName = horizontalNav ? "MenuHorizontal" : "Menu";
		//	return PartialView(viewName, categories);
		//}

		public PartialViewResult Menu(string category = null, bool horizontalNav = false)
		{
			ViewBag.SelectedCategory = category;

			IEnumerable<string> categories = repository.Products
				.Select(prod => prod.Category)
				.Distinct()
				.OrderBy(x => x);
			return PartialView( categories);
			//return PartialView("FlexMenu", categories);
		}
	}
}