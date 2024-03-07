using System.ComponentModel.DataAnnotations;

namespace FreelanceCoreProject.Areas.Employer.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string Password { get; set; }
    }
}
