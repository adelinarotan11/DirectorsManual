using System;
using System.Collections.Generic;
using System.Text;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Domain.Abstract;
using System.Linq;

namespace DirectorsManual.Domain.Concrete
{//Класс EFProductRepository представляет необходимое хранилище
	public class EFProductRepository : IProductRepository
	{
		EFDbContext context = new EFDbContext();//извлечение данных из бд

		public IEnumerable<TProduct> Products
		{
			get { return context.Products; }
		}
		public IEnumerable<TCompany>Companies 
		{
			get { return context.Companies; }
		}
		public IEnumerable<TCustomer> Customers
		{
			get { return context.Customers; }
		}
		public IEnumerable<TContract_product> Contract_Products
		{
			get { return context.Contract_Products; }
		}
		public IEnumerable<TDetail> Details
		{
			get { return context.Details; }
		}
		public IEnumerable<TContract_detail> Contract_Details
		{
			get { return context.Contract_Details; }
		}
		public IEnumerable<TStockDetails> StockDetails
		{
			get { return context.StockDetails; }
		}
		public IEnumerable<TAssemblyProduct> AssemblyProducts
		{
			get { return context.AssemblyProducts; }
		}
		public IEnumerable<TProvider> Providers
		{
			get { return context.Providers; }
		}

		public void SaveProduct(TProduct prod)
		{
			if (prod.ID == 0)
				context.Products.Add(prod);
			else
			{
				TProduct dbEntry = context.Products.Find(prod.ID);
				if (dbEntry != null)
				{
					dbEntry.Name_Product = prod.Name_Product;
					dbEntry.Description = prod.Description;
					dbEntry.Price = prod.Price;
					dbEntry.Category = prod.Category;
					dbEntry.ImageData = prod.ImageData;
					dbEntry.ImageMimeType = prod.ImageMimeType;
				}
			}
			context.SaveChanges();
		}

		public TProduct DeleteProduct(int prodId)
		{
			TProduct dbEntry = context.Products.Find(prodId);
			if (dbEntry != null)
			{
				context.Products.Remove(dbEntry);
				context.SaveChanges();
			}
			return dbEntry;
		}

	
	}
}

