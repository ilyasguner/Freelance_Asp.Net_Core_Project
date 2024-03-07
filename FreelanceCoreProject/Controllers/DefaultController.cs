using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult HeaderPartial()
		{
			return View();
		}


	}
}
