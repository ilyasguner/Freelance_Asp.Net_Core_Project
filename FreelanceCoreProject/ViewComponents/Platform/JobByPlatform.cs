using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.ViewComponents.Platform
{
	public class JobByPlatform:ViewComponent
	{
		JobManager jobManager = new JobManager(new EfJobDal());
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = jobManager.TGetList().Where(x => x.PlatformId == 1).Count();
			ViewBag.v2 = jobManager.TGetList().Where(x => x.PlatformId == 2).Count();
			ViewBag.v3 = jobManager.TGetList().Where(x => x.PlatformId == 3).Count();
			ViewBag.v4 = jobManager.TGetList().Where(x => x.PlatformId == 4).Count();
			ViewBag.v5 = jobManager.TGetList().Where(x => x.PlatformId == 5).Count();
			return View();
		}
	}
}
