using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Controllers
{
	public class AdminJobFilterController : Controller
	{
		JobManager jobManager = new JobManager(new EfJobDal());

		//admin kategoriye göre iş filtreleme
		public IActionResult CategoryFilter(int id)
		{
			var values = jobManager.TGetList().Where(x => x.CategoryId == id).ToList();
			return View(values);
		}

		//admin plaforma göre iş filtreleme
		public IActionResult PlatformFilter(int id)
		{
			var values = jobManager.TGetList().Where(x => x.PlatformId == id).ToList();
			return View(values);
		}

		//admin yarızamanlıiş filtreleme
        public IActionResult YariZamanli()
        {
            var values = jobManager.TGetList().Where(x => x.JobTypeId==1).ToList();
            return View(values);
        }

		//admin tamzamanlı iş filtreleme
		public IActionResult TamZamanli()
		{
			var values = jobManager.TGetList().Where(x => x.JobTypeId == 0).ToList();
			return View(values);
		}
    }
}
