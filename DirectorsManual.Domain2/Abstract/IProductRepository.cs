using System;
using System.Collections.Generic;
using System.Text;
using DirectorsManual.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DirectorsManual.Domain.Abstract
{
	public interface IProductRepository
	{
		IEnumerable<TProduct> Products { get; }
		IEnumerable<TCompany> Companies { get; }
		IEnumerable<TCustomer> Customers { get; }
		IEnumerable<TProvider> Providers { get; }
		IEnumerable<TContract_product> Contract_Products { get; }
		IEnumerable<TDetail> Details { get; }
		IEnumerable<TContract_detail> Contract_Details { get; }
		IEnumerable<TStockDetails> StockDetails { get; }
		IEnumerable<TAssemblyProduct> AssemblyProducts { get; }
		void SaveProduct(TProduct prod);
		TProduct DeleteProduct(int prodId);
		
	}
}
