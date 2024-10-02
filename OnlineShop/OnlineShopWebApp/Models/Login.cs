using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Не указан email")]
        [EmailAddress(ErrorMessage ="Введите валидный email")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(15, MinimumLength = 4, ErrorMessage="Пароль должен содержать ль 4 до 15 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
