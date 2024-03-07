using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Controllers
{
	public class JobFilterController : Controller
	{
		JobManager jobManager = new JobManager(new EfJobDal());

		//Kategoriye göre işlerin listelenmesi
		public IActionResult Index(int id)
		{
			var values = jobManager.TGetList().Where(x => x.CategoryId == id).ToList();
			return View(values);
		}

		//Platforma göre işlerin listelenmesi
		public IActionResult PlatformFilter(int id)
		{
			var values = jobManager.TGetList().Where(x => x.PlatformId == id).ToList();
			return View(values);
		}

		//Tam zamanlı işlerin listelenmesi
		public IActionResult TamZamanli()
		{
			var values = jobManager.TGetList().Where(x => x.JobTypeId == 0).ToList();
			return View(values);
		}

		//Yarı zamanlı işlerin listelenmesi
		public IActionResult YariZamanli()
		{
			var values = jobManager.TGetList().Where(x => x.JobTypeId == 1).ToList();
			return View(values);
		}
	}
}
