using System.ComponentModel.DataAnnotations;

namespace FreelanceCoreProject.Areas.Employer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string Name { get; set; }

        [Required(ErrorMessage ="Lütfen Soyadınızı Giriniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string Surname { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Mailinizi Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Lütfen Resim Yolunucu Giriniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string ImagerUrl { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifrelere Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        public int EmployerRole { get; set; }
    }
}
