using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Authorize]
    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
