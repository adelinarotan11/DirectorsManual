using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DirectorsManual.Domain.Entities;
using System.Web.Mvc;
namespace DirectorsManual.Web.Infrastructure
{
	public class CartModelBinder : IModelBinder//специальный связыватель модели
	{
		private const string sessionKey = "Cart";

		public object BindModel(ControllerContext controllerContext,
			ModelBindingContext bindingContext)
		{
			// Получить объект Cart из сеанса
			Cart cart = null;
			if (controllerContext.HttpContext.Session != null)
			{
				cart = (Cart)controllerContext.HttpContext.Session[sessionKey];//извлечь объект из состояния сеанса
			}

			// Создать объект Cart если он не обнаружен в сеансе
			if (cart == null)
			{
				cart = new Cart();
				if (controllerContext.HttpContext.Session != null)
				{
					controllerContext.HttpContext.Session[sessionKey] = cart;//добавить объект в состояние сеанса
				}
			}

			// Возвратить объект Cart
			return cart;
		}
	}
}