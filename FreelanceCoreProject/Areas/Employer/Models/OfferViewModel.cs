using System.ComponentModel.DataAnnotations;

namespace FreelanceCoreProject.Areas.Employer.Models
{
    public class OfferViewModel
    {

        public string EmployerUserName { get; set; }

        public string JobName { get; set; }

        [Required(ErrorMessage = "Teklif Edilen Ücret Kısmı Boş Bırakılamaz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public int Price { get; set; }

        [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
		[RegularExpression(@"^[^<]*$", ErrorMessage = "Özel ifadeler kullanılamaz")]
		public string Description { get; set; }

        public DateTime FinishDate { get; set; }
    }
}
