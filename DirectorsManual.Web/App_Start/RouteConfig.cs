using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DirectorsManual.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//routes.MapRoute(
			//   name: null,
			//   url: "Page{page}",
			//   defaults: new { controller = "Game", action = "List" }
			//  );

			//routes.MapRoute(
			//             name: "Default",
			//             url: "{controller}/{action}/{id}",
			//             defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
			//         );
			routes.MapRoute(
						 name: "Default",
						 url: "{controller}/{action}/{id}",
						 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                         namespaces: new[] { "DirectorsManual.Web.Controllers" }

                         );

			routes.MapRoute(null,// URL="/"
				"",
				new
				{
					controller = "Game",
					action = "List",
					category = (string)null,
					page = 1
				}
			);

			routes.MapRoute(// URL="/Page2"
				name: null,
				url: "Page{page}",
				defaults: new { controller = "Game", action = "List", category = (string)null },
				constraints: new { page = @"\d+" }
			);

			routes.MapRoute(null,// URL="/Симулятор(category):"Отображает 1 страницу элементов указанной категории
			   "{category}",
			   new { controller = "Game", action = "List", page = 1 }
		   );

			routes.MapRoute(null,//// URL="/Симулятор/Page2 :Отображает заданную страницу(страницу 2)элементов указанной категории (Симулятор)
				"{category}/Page{page}",
				new { controller = "Game", action = "List" },
				new { page = @"\d+" }
			);

			routes.MapRoute(null, "{controller}/{action}");

			
		}
	}
}
