using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.ViewComponents.Job
{
	public class JobList:ViewComponent
	{
		JobManager jobManager = new JobManager(new EfJobDal());

		public IViewComponentResult Invoke()
		{
			//en yüksek fiyatlı 10 projenin listelenmesi
			var values = jobManager.TGetList().OrderByDescending(x => x.Price).Take(10).ToList();
			return View(values);
		}
	}
}
