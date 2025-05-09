using System.ComponentModel.DataAnnotations;

namespace Ekitap.WebUI.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress),Required(ErrorMessage = "Geçerli bir E-Posta adresi yazınız!")]
        public string Email { get; set; }
        [Display(Name ="Şifre"), Required(ErrorMessage = "Lütfen Şifrenizi giriniz!")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
