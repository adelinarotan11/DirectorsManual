using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Entities;
using DirectorsManual.Web.Models;

namespace DirectorsManual.Web.Controllers
{
    public class ProductController : Controller
    {
		private IProductRepository repository;
		public int pageSize = 4;
		public ProductController(IProductRepository repo)//конструктор, который объявляет зависимость от интерфейса IGameRepository
		{
			repository = repo;
			//приводит к внедрению библиотекой Ninject данной
			//зависимости для хранилища товаров при создании экземпляра класса контроллера
		}

		public ViewResult List(string category, int page = 1)
		{
			ProductsListViewModel model = new ProductsListViewModel
			{
				Products = repository.Products
					.Where(p => category == null || p.Category == category)
					.OrderBy(prod => prod.ID)
					.Skip((page - 1) * pageSize)
					.Take(pageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = pageSize,
					TotalItems = category == null ?
			repository.Products.Count() :
			repository.Products.Where(prod => prod.Category == category).Count()
				},
				CurrentCategory = category
			};
			return View(model);
		}

		public FileContentResult GetImage(int ID)
		{
			TProduct product = repository.Products
				.FirstOrDefault(g => g.ID == ID);

			if (product != null)
			{
				return File(product.ImageData, product.ImageMimeType);
			}
			else
			{
				return null;
			}
		}
       
        //public ViewResult List()
        //{
        //	//будет визуализировать представление, отображающее полный список товаров
        //	return View(repository.Products);
        //}
    }
}