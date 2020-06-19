using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using DirectorsManual.Domain.Abstract;
using DirectorsManual.Domain.Entities;

namespace DirectorsManual.Domain.Concrete
{
	public class EmailSettings
	{
		public string MailToAddress = "oksanarotan15@gmail.com";
		public string MailFromAddress = "oksanarotan15@gmail.com";
		public bool UseSsl = true;
		public string Username = "oksanarotan15@gmail.com";
		public string Password = "rotan223";
		public string ServerName = "smtp.gmail.com";
		public int ServerPort = 587;
		public bool WriteAsFile = false;
		//public string FileLocation = @"c:\game_store_emails";
	}

	public class EmailOrderProcessor : IOrderProcessor
	{
		private EmailSettings emailSettings;

		public EmailOrderProcessor(EmailSettings settings)
		{
			emailSettings = settings;
		}

		public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
		{
			using (var smtpClient = new SmtpClient())
			{
				smtpClient.EnableSsl = emailSettings.UseSsl;
				smtpClient.Host = emailSettings.ServerName;
				smtpClient.Port = emailSettings.ServerPort;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials
					= new NetworkCredential(emailSettings.Username, emailSettings.Password);

				//if (emailSettings.WriteAsFile)
				//{
				//	smtpClient.DeliveryMethod
				//		= SmtpDeliveryMethod.SpecifiedPickupDirectory;
				//	smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
				//	smtpClient.EnableSsl = false;
				//}

				StringBuilder body = new StringBuilder()
					.AppendLine("Новый заказ обработан")
					.AppendLine("---")
					.AppendLine("Товары:");

				foreach (var line in cart.Lines)
				{
					var subtotal = line.Product.Price * line.Quantity;
					body.AppendFormat("{0} x {1} (итого: {2:c}",
						line.Quantity, line.Product.Name_Product, subtotal);
				}

				body.AppendFormat("Общая стоимость заказа: {0:c}", cart.ComputeTotalValue())
					.AppendLine("---")
					.AppendLine("Доставка:")
					.AppendFormat("ФИО получателя: {0};", shippingInfo.Name)
                    .AppendLine("")
                    .AppendFormat("Номер телефона получателя: {0};", shippingInfo.Phone)
                    .AppendLine("")
                    .AppendFormat("Страна: {0};", shippingInfo.Country)
                    .AppendLine("")
                    .AppendFormat("Город: {0};", shippingInfo.City)
                    .AppendLine("")
                    .AppendFormat("Адрес: {0};", shippingInfo.Line1)
                    .AppendLine("")
					.AppendFormat("Подарочная упаковка: {0}.",
						shippingInfo.GiftWrap ? "Да" : "Нет");

				MailMessage mailMessage = new MailMessage(
									   emailSettings.MailFromAddress,   // От кого
									   emailSettings.MailToAddress,     // Кому
									   "Новый заказ отправлен!",        // Тема
									   body.ToString());                // Тело письма

				if (emailSettings.WriteAsFile)
				{
					mailMessage.BodyEncoding = Encoding.UTF8;
				}

				smtpClient.Send(mailMessage);
			}
		}
	}
}
