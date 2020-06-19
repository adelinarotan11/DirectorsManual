using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Concrete;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Web.Areas.Admin.Models;

namespace DirectorsManual.Web.Areas.Admin.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminController : Controller
	{
		IProductRepository repository;
        EFDbContext db = new EFDbContext();
        public AdminController(IProductRepository repo)
		{
			repository = repo;
		}

		public ViewResult Index()
		{
			return View(repository.Products);
		}



		public ViewResult Rez1StopP()
		{
			return View(repository.Contract_Products);
		}

		public ActionResult FirstStorageProcedure()
		{
			Procedure1_AddCP v = new Procedure1_AddCP();
			v.TypeOfCustomers = from var in repository.Customers select var.Name_Customer;
			v.TypeOfCompanies = from var in repository.Companies select var.Name_C;
			return View(v);
			
		}

		[HttpPost]
		public ActionResult FirstStorageProcedure(Procedure1_AddCP proc, TContract_product v)
		{
			if (ModelState.IsValid)
			{
				using (var context=new EFDbContext())
			{
				string Name_customer=proc.CustomerName;
				string Name_company = proc.CompanyName;
				int KolProduct = proc.Kolvo_Products;
				float PriceProduct = proc.Price_Product;
				DateTime DateDeliveryProduct = proc.Date_delivery_product;


				var data=context.Database.ExecuteSqlCommand(" EXEC [dbo].[Add_Inf_in_the_Contract_Product] @Name_customer, @Name_company, @KolProduct," +
					"@PriceProduct, @DateDeliveryProduct",
					
					new SqlParameter("Name_customer", Name_customer),
					new SqlParameter("Name_company", Name_company),
					new SqlParameter("KolProduct", KolProduct),
					new SqlParameter("PriceProduct", PriceProduct),
					new SqlParameter("DateDeliveryProduct", DateDeliveryProduct));
				return RedirectToAction("Rez1StopP");
			}
			}
			else
			{
				// Что-то не так со значениями данных
				return View();
			}

		}



		public ViewResult Rez2StopP()
		{
			return View(repository.Contract_Details);
		}

		public ActionResult SecondStorageProcedure()
		{
			Procedure2_AddCD v = new Procedure2_AddCD();
			v.TypeOfProviders =from var in repository.Providers select var.Name_prov;
			v.TypeOfCompanies = from var in repository.Companies select var.Name_C;
			return View(v);
		}

		[HttpPost]
		public ActionResult SecondStorageProcedure(Procedure2_AddCD proc)
		{
			if (ModelState.IsValid)
			{
				using (var context = new EFDbContext())
				{
					string Name_provider = proc.Name_provider;
					string Name_company = proc.Name_company;
					int KolDetails = proc.KolDetails;
					float PriceDetails = proc.PriceDetails;
					DateTime DateDeliveryDetails = proc.DateDeliveryDetails;


					var data = context.Database.ExecuteSqlCommand(" EXEC [dbo].[Add_Inf_in_the_Contract_Details] @Name_provider, @Name_company, @DateDeliveryDetails," +
						"@KolDetails, @PriceDetails",

						new SqlParameter("Name_provider", Name_provider),
						new SqlParameter("Name_company", Name_company),
						new SqlParameter("DateDeliveryDetails", DateDeliveryDetails),
						new SqlParameter("KolDetails", KolDetails),
						new SqlParameter("PriceDetails", PriceDetails));
					return RedirectToAction("Rez2StopP");
				}
			}
			else
			{
				// Что-то не так со значениями данных
				return View();
			}

		}





        public async Task<ActionResult> Edit(int? ID)
        {


            ViewBag.message = "Редактирование товaра - ";
            if (ID == null)
                return HttpNotFound();
            TProduct prod = await db.Products.FindAsync(ID);
            if (ID != null)
                return View(prod);
            return HttpNotFound();
        }

		// Перегруженная версия Edit() для сохранения изменений
		[HttpPost]
		public async Task<ActionResult> Edit(TProduct prod, HttpPostedFileBase image = null)
		{
			if (ModelState.IsValid)
			{
				if (image != null)
				{
					prod.ImageMimeType = image.ContentType;
					prod.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(prod.ImageData, 0, image.ContentLength);
				}
                db.Entry(prod).State = EntityState.Modified;
                await db.SaveChangesAsync();

                //repository.SaveProduct(prod);
				TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", prod.Name_Product);
				
				return RedirectToAction("Index");
			}
			else
			{
				// Что-то не так со значениями данных
				return View(prod);
			}
		}

		public ActionResult Func1()
		{
                return View();
        }

        [HttpPost]
        public ActionResult Func1Partial(int ID)
        {
           
            
                var custs = from c in repository.Contract_Products
                            join v in repository.Customers on c.CustomerID equals v.ID
                            where v.ID == ID
                            group c by v.Name_Customer into rez
                            select new FunctionsModel()
                            {
                                IdOfCurrentCustomer = rez.Key,
                                SummProfit = rez.Sum(x => x.Price_Product * x.Kolvo_Products)

                            };
                if (custs.ToList().Count==0)
                {
                TempData["message"] = string.Format("Некорректные данные! Покупатель с таким id не существует!");
                return PartialView();
                }
                return PartialView(custs.ToList());
            }
           
        
        public ViewResult Func2()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Func2Partial(int ID)
		{
				var custs = from contD in repository.Contract_Details
							join Det in repository.Details on contD.ID equals Det.Contract_detailID
							join Stok in repository.StockDetails on Det.ID equals Stok.DetailID
							where contD.ID == ID && (contD.Kolvo_Detail - Stok.KolvoDetail) > 0
							group new { contD, Det, Stok } by new
							{
								Det.Name_Detail,
								contD.Kolvo_Detail,
								Stok.KolvoDetail

							} into rez
							select new FunctionsModel2()
							{
								NameofDetail = rez.Key.Name_Detail,
								kolDetailInCont = rez.Key.Kolvo_Detail,
								kolDetailInStock=rez.Key.KolvoDetail,
								NecessaryOrderDet=rez.Key.Kolvo_Detail-rez.Key.KolvoDetail

							};
            if (custs.ToList().Count == 0)
            {
                TempData["message"] = string.Format("Некорректные данные! Договор с таким id не существует!");
                return PartialView();
            }
            return PartialView(custs.ToList());
			
	}

		public ViewResult Func3()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Func3Partial(int ID)
        {
			
				var custs = from contD in repository.Contract_Details
							join Det in repository.Details on contD.ID equals Det.Contract_detailID
							join Stok in repository.StockDetails on Det.ID equals Stok.DetailID
							join Assem in repository.AssemblyProducts on Stok.ID equals Assem.StockDetailsID
							join Prod in repository.Products on Assem.ProductID equals Prod.ID
							join contP in repository.Contract_Products on Prod.Contract_ProductID equals contP.ID
							where Prod.Contract_ProductID == ID
							group new { contP, contD, Assem } by new
							{
								contP.ID

							} into rez

							select new FunctionsModel3()
							{
								idContProd = rez.Key.ID,
								SummProfit = rez.Sum(v=>
								{
									float v1 = (v.contD.Price_detail * v.Assem.Kolvo_Needed_Details);
									return (v.contP.Price_Product * v.contP.Kolvo_Products) - v1;
								})
							};

            if (custs.ToList().Count == 0)
            {
                TempData["message"] = string.Format("Некорректные данные! Договор с таким id не существует!");
                return PartialView();
            }
            return PartialView(custs.ToList());
		
		}


		public ViewResult Func4()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Func4Partial(int ID)
        {
			
				var custs = from contD in repository.Contract_Details
							join Det in repository.Details on contD.ID equals Det.Contract_detailID
							join Stok in repository.StockDetails on Det.ID equals Stok.DetailID
							join Assem in repository.AssemblyProducts on Stok.ID equals Assem.StockDetailsID
							join Prod in repository.Products on Assem.ProductID equals Prod.ID
							join contP in repository.Contract_Products on Prod.Contract_ProductID equals contP.ID
							where Prod.Contract_ProductID == ID
							//group contP by contP.ID into rez
							group new { Prod, Det, Assem } by new
							{
								Prod.Name_Product,
								Det.Name_Detail,
								Assem.Kolvo_Needed_Details
								

							} into rez

							select new FunctionsModel4()
							{
								NameofProduct = rez.Key.Name_Product,
								NameofDetail = rez.Key.Name_Detail,
								KolNeededDetails = rez.Key.Kolvo_Needed_Details
								
							};
            if (custs.ToList().Count == 0)
            {
                TempData["message"] = string.Format("Некорректные данные или договор с таким id не существует!");
                return PartialView();
            }
            return PartialView(custs.ToList());
			
		}

		public ViewResult Func5()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Func5Partial(DateTime date)
		{
				var custs = from contD in repository.Contract_Details
							join prov in repository.Providers on contD.ProviderID equals prov.ID
							where contD.Date_delivery_detail != date
							//group contP by contP.ID into rez
							group new { contD, prov} by new
							{
								contD.ProviderID,
								prov.Name_prov

							} into rez

							select new FunctionsModel5()
							{
								NameofProv = rez.Key.Name_prov
							};
            
            return PartialView(custs.ToList());
			
		}
		public ViewResult Create()
		{
			ViewBag.message = "Добавление нового товaра";
			return View("Edit", new TProduct());
		}

		[HttpPost]
		public ActionResult Delete(int ID)
		{
			TProduct deletedProd = repository.DeleteProduct(ID);
			if (deletedProd != null)
			{
				TempData["message"] = string.Format("Игра \"{0}\" была удалена",
					deletedProd.Name_Product);
			}
			return RedirectToAction("Index");
		}




		

	}
}