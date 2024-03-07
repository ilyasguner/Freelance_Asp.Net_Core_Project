using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FreelanceCoreProject.Areas.Employer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
	[Area("Employer")]
	[Authorize]
	public class OfferController : Controller
	{
		OfferManager offerManager = new OfferManager(new EfOfferDal());
        public readonly UserManager<Employers> _userManager;
        string employerUserName = "";
        string jobName = "";
        public OfferController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult GiveOffer(int id)
		{
			Context c = new Context();
            ViewBag.v1 = c.Jobs.FirstOrDefault(x => x.JobId == id).JobName.ToString();
            ViewBag.v2 = c.Jobs.FirstOrDefault(x => x.JobId == id).EmployerUserName.ToString();
			return View();
		}


        [HttpPost]
        public async Task<IActionResult> GiveOffer(OfferViewModel offerViewModel)
        {
            ViewBag.v1 = offerViewModel.JobName;
            ViewBag.v2 = offerViewModel.EmployerUserName;
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            Offer offer = new Offer()
            {
                EmployerUserName = offerViewModel.EmployerUserName,
                WorkerUserName = values.UserName,
                JobName = offerViewModel.JobName,
                Price = offerViewModel.Price,
                Description = offerViewModel.Description,
                OfferDate = DateTime.Now,
                Status = false,
                FinishDate = offerViewModel.FinishDate

            };

            if(offerViewModel.EmployerUserName==values.UserName)
            {
                return View();
            }
           
            offerManager.TAdd(offer);
            
            return RedirectToAction("Index", "HomePage", new { area = "Employer" });
        }
    }
}
