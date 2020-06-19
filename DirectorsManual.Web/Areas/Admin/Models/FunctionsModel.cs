using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DirectorsManual.Domain.Entities;

namespace DirectorsManual.Web.Areas.Admin.Models
{//Вспомогательные модели для хранения новых таблиц, полученных в результате выполнения функции

	public class FunctionsModel
	{
       
        public string IdOfCurrentCustomer { get; set; }
		public double SummProfit { get; set; }
	}

	public class FunctionsModel2
	{
		public string NameofDetail { get; set; }
		public int kolDetailInCont { get; set; }
		public int kolDetailInStock { get; set; }
		public int NecessaryOrderDet { get; set; }
	}

	public class FunctionsModel3
	{
		public int idContProd { get; set; }
		public float SummProfit { get; set; }
	}
	
	public class FunctionsModel4
	{
		public string NameofProduct { get; set; }
		public string NameofDetail { get; set; }
		public int KolNeededDetails { get; set; }
		
	}
	
	public class FunctionsModel5
	{
		
		public string NameofProv { get; set; }

	}

	//public class funcdate
	//{

	//	[DataType(DataType.Date, ErrorMessage = "Date only")]
	//	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	//	public string CurrentDate { get; set; }
	//}



	public class Procedure1_AddCP
	{

		[Display(Name = "Введите название компании у которой вы желаете приобрести товар:")]
		public string CompanyName { get; set; }
		
		[Display(Name = "Введите ФиИО покупателя:")]
		public string CustomerName { get; set; }
		
		public int Kolvo_Products { get; set; }
		public float Price_Product { get; set; }//summary price for all the products in the contract

		[DataType(DataType.Date, ErrorMessage = "Date only")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Date_delivery_product { get; set; }

		public IEnumerable<string> TypeOfCustomers { get; set; }
		public IEnumerable<string> TypeOfCompanies { get; set; }
	}
	public class Procedure2_AddCD
	{

		[Display(Name = "Введите ФИО поставщика:")]
		public string Name_provider { get; set; }//foreign key

		[Display(Name = "Введите название компании для которой поставляются детали:")]
		public string Name_company { get; set; }

		[DataType(DataType.Date, ErrorMessage = "Date only")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DateDeliveryDetails { get; set; }

		public int KolDetails { get; set; }//summary price for all the products in the contract
		public float PriceDetails { get; set; }

		public IEnumerable<string> TypeOfProviders { get; set; }
		public IEnumerable<string> TypeOfCompanies { get; set; }
	}

	//public class ListOptionModel
	//{
	//	public List<TProvider> Providers { get; set; }
	//	public List<TCompany> Companies { get; set; }
	//	public List<TCustomer> TypeOfCustomer { get; set; }
	//}
}