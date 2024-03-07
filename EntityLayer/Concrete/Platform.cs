using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Platform
	{
        [Key]
        public int PlatformId { get; set; }

        public string PlatformName { get; set; }
    }
}
