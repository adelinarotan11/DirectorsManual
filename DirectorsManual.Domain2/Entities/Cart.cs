using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DirectorsManual.Domain.Entities
{
	public class CartLine
	{// представляет товар, выбранный пользователем, а также приобретаемое его количество
		public TProduct Product { get; set; }
		public int Quantity { get; set; }
	}

	public class Cart
	{
		private List<CartLine> lineCollection = new List<CartLine>();

		public void AddItem(TProduct prod, int quantity)
		{
			CartLine line = lineCollection
				.Where(g => g.Product.ID == prod.ID)
				.FirstOrDefault();

			if (line == null)
			{
				lineCollection.Add(new CartLine
				{
					Product = prod,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(TProduct product)
		{
			lineCollection.RemoveAll(l => l.Product.ID == product.ID);
		}

		public decimal ComputeTotalValue()
		{
			return lineCollection.Sum(e => e.Product.Price * e.Quantity);

		}
		public void Clear()
		{
			lineCollection.Clear();
		}

		public IEnumerable<CartLine> Lines
		{
			get { return lineCollection; }
		}
	}

	
}
