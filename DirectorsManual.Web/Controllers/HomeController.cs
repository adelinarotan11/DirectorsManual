using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectorsManual.Web.Controllers
{
	[RequireHttps]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}
		
		public ActionResult FormulationTask()
		{
			ViewBag.Message = "StroyProekt";
			return View();
		}
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		
	}
}