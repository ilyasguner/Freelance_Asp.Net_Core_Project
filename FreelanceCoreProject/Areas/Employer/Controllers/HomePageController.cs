using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("Employer/[Controller]/[action]")]
    [Authorize]
    public class HomePageController : Controller
    {
        private readonly UserManager<Employers> _userManager;

        public HomePageController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }


        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //string api = "55fc84c41bdede2ba4bc962332e0f49f";
            //string connection = "https://api.openweathermap.org/data/2.5/weather?q=London&mode=xml&lang=tr&units=metric&appid=" + api;

            //XDocument document = XDocument.Load(connection);

            //ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v6 = "15 C";
            Context c = new Context();
            ViewBag.v1 = c.Jobs.Where(x=>x.EmployerUserName==values.UserName).Count();
            ViewBag.v2 = c.Offers.Where(x => x.WorkerUserName == values.UserName && x.Approval==2).Count(); 
            ViewBag.v3 = c.Offers.Where(x=>x.WorkerUserName==values.UserName && x.Status==true).Count(); 
            ViewBag.v4 = c.Offers.Where(x => x.WorkerUserName == values.UserName && x.Status == false).Count();
            ViewBag.v5 = c.Users.FirstOrDefault(x => x.UserName == values.UserName).Money;
            return View();
        }

    }
}
