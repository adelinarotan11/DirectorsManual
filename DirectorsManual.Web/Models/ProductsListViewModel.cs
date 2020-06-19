using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DirectorsManual.Domain.Entities;

namespace DirectorsManual.Web.Models
{
	public class ProductsListViewModel
	{
		public IEnumerable<TProduct> Products { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string CurrentCategory { get; set; }//категория товара из бд
	}
}