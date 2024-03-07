using System.ComponentModel.DataAnnotations;

namespace FreelanceCoreProject.Areas.Employer.Models
{
	public class AnnouncementViewModel
	{
		
		[Required(ErrorMessage = "İş Adı Boş Bırakılamaz")]
        [RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler Kullanılamaz")]
        public string JobName { get; set; }

		[Required(ErrorMessage ="İş Açıklaması Boş Bırakılamaz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string JobContent { get; set; }

        [Required(ErrorMessage = "İş Ücreti Boş Bırakılamaz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public int Price { get; set; }

		[Required(ErrorMessage = "Tarih Belirtilmelidir")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage ="İş Tipini Belirtmelisiniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public int JobTypeId { get; set; }

		[Required(ErrorMessage = "Category Tipini Belirtmelisiniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Platform Tipini Belirtmelisiniz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public int PlatformId { get; set; }


	}
}
