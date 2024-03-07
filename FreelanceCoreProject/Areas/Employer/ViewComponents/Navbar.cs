using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.ViewComponents
{
	public class Navbar:ViewComponent
	{
		public readonly UserManager<Employers> _userManager;

		public Navbar(UserManager<Employers> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.v = values.ImageUrl;
			return View(values);
		}
	}
}
