using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.ViewComponents.Category
{
	public class JobByCategory:ViewComponent
	{
		JobManager jobManager = new JobManager(new EfJobDal());

		public IViewComponentResult Invoke()
		{
			ViewBag.v1= jobManager.TGetList().Where(x=>x.CategoryId==1).Count();
			ViewBag.v2= jobManager.TGetList().Where(x=>x.CategoryId==2).Count();
			ViewBag.v3= jobManager.TGetList().Where(x=>x.CategoryId==3).Count();
			ViewBag.v4= jobManager.TGetList().Where(x=>x.CategoryId==5).Count();
			ViewBag.v5= jobManager.TGetList().Where(x=>x.CategoryId==6).Count();
			ViewBag.v6= jobManager.TGetList().Where(x=>x.CategoryId==7).Count();
			return View();
		}
	}
}
