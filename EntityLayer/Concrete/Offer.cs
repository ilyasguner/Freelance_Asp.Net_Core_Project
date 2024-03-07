using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Offer
	{
		[Key]
		public int OfferId { get; set; }

		public string WorkerUserName { get; set; }

        public string EmployerUserName { get; set; }

        public string JobName { get; set; }

		public int Price { get; set; }

		public string Description { get; set; }

		public DateTime OfferDate { get; set; }

        public DateTime FinishDate { get; set; }

        public bool Status { get; set; }

        public int Approval { get; set; }

        public bool Delivery { get; set; }
    }
}
