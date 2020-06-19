using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DirectorsManual.Domain.Entities;

namespace DirectorsManual.Web.Models
{
	public class CartIndexViewModel
	{
		public Cart Cart { get; set; }
		public string ReturnUrl { get; set; }//URL для отображения, когда пользователь щелкает на кнопке "Продолжить покупку"
	}
}