using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("Employer/Budget/")]
    public class BudgetController : Controller
	{
        private readonly UserManager<Employers> _userManager;

        public BudgetController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }
		//yazilimci20
		//214ibrhm20
		[Route("")]
        [Route("WithdrawMoney")]
        [HttpPost]
        public async Task<IActionResult> WithdrawMoney()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if(values.Money>=10000)
            {
                values.Money -= 10000;
                await _userManager.UpdateAsync(values);
            }
            return RedirectToAction("Index", "HomePage", new { area = "Employer" });
        }

        [Route("")]
        [Route("AddMoney")]
        [HttpPost]
        public async Task<IActionResult> AddMoney()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Money += 10000;
            await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "HomePage", new { area = "Employer" });
        }


    }
}
