using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DirectorsManual.Domain.Entities
{
	public class ShippingDetails
	{
		[Required(ErrorMessage = "Укажите ваши данные")]
        [Display(Name = "ФИО получателя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Укажите адрес доставки")]
		[Display(Name = "Адрес доставки")]
		public string Line1 { get; set; }

    
        [DataType(DataType.EmailAddress, ErrorMessage = "Некорректный Email")]
        [Display(Name = "Введите Email")]
		public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Некорректный номер телефона")]
        [Display(Name = "Введите номер телефона")]
		public string Phone { get; set; }

		

		public bool GiftWrap { get; set; }
	}
}
