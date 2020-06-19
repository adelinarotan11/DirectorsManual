using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectorsManual.Domain.Entities
{
	[Table("TProduct", Schema = "dbo")]
	public class TProduct
	{
		[HiddenInput(DisplayValue=false)]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Display(Name = "Введите id компании у которой вы желаете приобрести товар:")]
		public int CompanyID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TCompany Company { get; set; }//навигационнoe свойство

		[Display(Name = "Введите ваш id:")]
		public int CustomerID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TCustomer Customer { get; set; }

		[Display(Name = "Введите номер вашего договора:")]
		public int Contract_ProductID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TContract_product Contract_Product { get; set; }

		[Display(Name = "Название")]
		[Required(ErrorMessage = "Пожалуйста, введите название товара")]
		public string Name_Product { get; set; }

		[DataType(DataType.MultilineText)]
		[Display(Name = "Описание")]
		[Required(ErrorMessage = "Пожалуйста, введите описание для товара")]
		public string Description { get; set; }

		[Display(Name = "Категория")]
		[Required(ErrorMessage = "Пожалуйста, укажите категорию для товара")]
		public string Category { get; set; }

		[Display(Name = "Цена (грн.)")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для товара")]
		public decimal Price { get; set; }
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
	}

	[Table("TCompany", Schema = "dbo")]
	public class TCompany
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name_C { get; set; }
		public string Address_C { get; set; }
		public string FIO_Director { get; set; }
	}
	[Table("TCustomer", Schema = "dbo")]
	public class TCustomer
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name_Customer { get; set; }
	}

	[Table("TProvider", Schema = "dbo")]
	public class TProvider
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name_prov { get; set; }
	}

	[Table("TContract_product", Schema = "dbo")]
	public class TContract_product
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Display(Name = "Введите id компании у которой вы желаете приобрести товар:")]
		public int CompanyID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TCompany Company { get; set; }//навигационнoe свойство

		[Display(Name = "Введите ваш id:")]
		public int CustomerID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TCustomer Customer { get; set; }

		public int Kolvo_Products { get; set; }
		public float Price_Product { get; set; }//summary price for all the products in the contract
		public DateTime Date_delivery_product { get; set; }
	}

	[Table("TContract_detail", Schema = "dbo")]
	public class TContract_detail
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Display(Name = "Введите id поставщика:")]
		public int ProviderID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TProvider Provider  { get; set; }//навигационнoe свойство

		[Display(Name = "Введите id компании у которой вы желаете приобрести товар:")]
		public int CompanyID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TCompany Company { get; set; }//навигационнoe свойство

		public DateTime Date_delivery_detail { get; set; }
		public int Kolvo_Detail { get; set; }
		public float Price_detail { get; set; }//summary price for all the products in the contract
	
	}

	[Table("TDetail", Schema = "dbo")]
	public class TDetail
	{
		[HiddenInput(DisplayValue = false)]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		
		[Display(Name = "Введите номер вашего договора на поставку:")]
		public int Contract_detailID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TContract_detail Contract_detail { get; set; }

		[Display(Name = "Введите id поставщика:")]
		public int ProviderID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TProvider Provider { get; set; }//навигационнoe свойство

		[Display(Name = "Введите id компании")]
		public int CompanyID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TCompany Company { get; set; }//навигационнoe свойство

		[Display(Name = "Название детали:")]
		[Required(ErrorMessage = "Пожалуйста, введите название детали")]
		public string Name_Detail { get; set; }
	}
	
	
	[Table("TStockDetails", Schema = "dbo")]
	public class TStockDetails
	{
		[HiddenInput(DisplayValue = false)]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Display(Name = "Введите id вашей детали:")]
		public int DetailID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TDetail Detail { get; set; }

		[Display(Name = "Введите номер вашего договора на поставку:")]
		public int Contract_detailID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TContract_detail Contract_detail { get; set; }

		[Display(Name = "Введите id поставщика:")]
		public int ProviderID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TProvider Provider { get; set; }//навигационнoe свойство

		[Display(Name = "Введите id компании")]
		public int CompanyID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TCompany Company { get; set; }//навигационнoe свойство

		[Display(Name = "Кол-во деталей:")]
		[Required(ErrorMessage = "Пожалуйста, введите кол-во деталей в наличии")]
		public int KolvoDetail { get; set; }
	}

	[Table("TAssemblyProduct", Schema = "dbo")]
	public class TAssemblyProduct
	{
		[HiddenInput(DisplayValue = false)]
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Display(Name = "Введите id товарa:")]
		public int ProductID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TProduct Product { get; set; }//навигационнoe свойство

		[Display(Name = "Введите id склада с которым был заключен договор:")]
		public int StockDetailsID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TStockDetails StockDetails { get; set; }//навигационнoe свойство

		[Display(Name = "Введите id компании")]
		public int CompanyID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TCompany Company { get; set; }//навигационнoe свойство
		
		[Display(Name = "Введите ваш id:")]
		public int CustomerID { get; set; }
		[HiddenInput(DisplayValue = false)]
		public virtual TCustomer Customer { get; set; }

		[Display(Name = "Введите id договора на покупку товара:")]
		public int Contract_productID { get; set; }//foreign key
		[HiddenInput(DisplayValue = false)]
		public virtual TContract_product Contract_Product { get; set; }//навигационнoe свойство

		[Display(Name = "Кол-во необходимых деталей для сборки:")]
		[Required(ErrorMessage = "Пожалуйста, введите кол-во деталей в наличии")]
		public int Kolvo_Needed_Details { get; set; }

		public DateTime Date_assembly_Product { get; set; }
	}
}
