using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DirectorsManual.Domain.Entities;
using System.Data.Entity.Infrastructure;

namespace DirectorsManual.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public DbSet<TProduct> Products { get; set; }
		public DbSet<TCompany> Companies { get; set; }
		public DbSet<TCustomer> Customers { get; set; }
		public DbSet<TProvider> Providers { get; set; }
		public DbSet<TContract_product> Contract_Products { get; set; }
		public DbSet<TDetail> Details { get; set; }
		public DbSet<TContract_detail> Contract_Details { get; set; }
		public DbSet<TStockDetails> StockDetails { get; set; }
		public DbSet<TAssemblyProduct> AssemblyProducts { get; set; }
	}
}
