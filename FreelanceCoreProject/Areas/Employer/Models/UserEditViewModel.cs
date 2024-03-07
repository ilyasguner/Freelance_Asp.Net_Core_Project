using System.ComponentModel.DataAnnotations;

namespace FreelanceCoreProject.Areas.Employer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Kısmı Boş Bırakılamaz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string UserName { get; set; }

        [Required(ErrorMessage = "Mail Kısmı Boş Bırakılamaz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string Email { get; set; }

        [Required(ErrorMessage ="Şifre Kısmı Boş Bırakılamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Şifre Tekrar Kısmı Boş Bırakılamaz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Resim Yolu Belirtilmeli")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Resim Seçiniz Lütfen")]
        public IFormFile Image { get; set; }
    }
}
