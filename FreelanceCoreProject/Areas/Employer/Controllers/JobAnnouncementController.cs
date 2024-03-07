using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FreelanceCoreProject.Areas.Employer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class JobAnnouncementController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());

        private readonly UserManager<Employers> _userManager;

        public JobAnnouncementController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddJobAnnouncement()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("AddJobAnnouncement")]
        public async Task<IActionResult> AddJobAnnouncement(AnnouncementViewModel p)
        {
			if (ModelState.IsValid)
			{
				var values = await _userManager.FindByNameAsync(User.Identity.Name);
                Job job = new Job()
                {
                    JobContent = p.JobContent,
                    JobName = p.JobName,
                    JobTypeId = p.JobTypeId,
                    CategoryId = p.CategoryId,
                    PlatformId = p.PlatformId,
                    AdvertDate = p.Date,
                    JobStatus = true,
                    EmployerUserName = values.UserName,
                    Price=p.Price
                };
				
				jobManager.TAdd(job);

				return RedirectToAction("Index", "HomePage", new { area = "Employer" });
			}
			else
			{
				// Hata mesajlarını al ve işle
				var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

				// Hata mesajlarını logla veya kullanıcıya göster
				foreach (var errorMessage in errorMessages)
				{
                    ModelState.AddModelError("", errorMessage);
				}
			}
            return View();
		}
    }
}
