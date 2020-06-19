using System;
using System.Collections.Generic;
using System.Text;
using DirectorsManual.Domain.Entities;
namespace DirectorsManual.Domain.Abstract
{
	public interface IOrderProcessor
	{
		void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
	}
}
