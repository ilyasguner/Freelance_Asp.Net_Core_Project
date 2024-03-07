using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.ViewComponents.Platform
{
	public class PlatformSection:ViewComponent
	{
		PlatformManager platformManager = new PlatformManager(new EfPlatformDal());

		public IViewComponentResult Invoke()
		{
			var values=platformManager.TGetList();
			return View(values);
		}


    }
}
