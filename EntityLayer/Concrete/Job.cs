using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Job
	{
		[Key]
		public int JobId { get; set; }
		public int JobTypeId { get; set; }
		public string JobName { get; set; }
		public string JobContent { get; set; }
		public int CategoryId { get; set; }
		public int PlatformId { get; set; }
		public int Price { get; set; }
		public DateTime AdvertDate { get; set; }
		public bool JobStatus { get; set; }
        public string EmployerUserName { get; set; }
    }
}
