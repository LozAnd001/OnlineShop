using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfoViewModel
    {
        [Required(ErrorMessage ="Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан адресс")]
        public string Address { get; set; }
    }
}
