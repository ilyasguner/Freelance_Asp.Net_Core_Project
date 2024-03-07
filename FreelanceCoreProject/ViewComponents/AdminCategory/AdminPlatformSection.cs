using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.ViewComponents.AdminCategory
{
	public class AdminPlatformSection:ViewComponent
	{
		PlatformManager platformManager = new PlatformManager(new EfPlatformDal());

		public IViewComponentResult Invoke()
		{
			var values = platformManager.TGetList();
			return View(values);
		}
	}
}
