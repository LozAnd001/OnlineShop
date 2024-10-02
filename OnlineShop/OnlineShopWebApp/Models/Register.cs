using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Пароль должен содержать ль 4 до 15 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Пароль должен содержать ль 4 до 15 символов")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
