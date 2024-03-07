using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class WorkFollowController : Controller
    {
        //JobDetailManager jobDetail = new JobDetailManager(new EfJobDetailDal());
        OfferManager offerManager = new OfferManager(new EfOfferDal());
        public readonly UserManager<Employers> _userManager;

        public WorkFollowController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        //verilen işlerin gösterilmesi
        [HttpGet]
        public async Task<IActionResult> GiveJobs()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = offerManager.TGetList().Where(x => x.EmployerUserName == user.UserName && x.Approval == 2).ToList();
            return View(values);
        }

        //alınan işlerin gösterilmesi
        [HttpGet]
        public async Task<IActionResult> ReceiverJobs()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = offerManager.TGetList().Where(x => x.WorkerUserName == user.UserName && x.Approval==2).ToList();
            return View(values);
        }
       
    }
}
