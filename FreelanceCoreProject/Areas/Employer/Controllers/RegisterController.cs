using EntityLayer.Concrete;
using FreelanceCoreProject.Areas.Employer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class RegisterController : Controller
    {
        private readonly UserManager<Employers> _userManager;

        public RegisterController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            //Model geçerliyse devam et
            if (ModelState.IsValid)
            {
                //yeni bir kullanıcı oluşturuyoruz
                Employers e = new Employers()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    ImageUrl = p.ImagerUrl,
                    Email = p.Mail,
                    EmployerRole=p.EmployerRole
                };

                var result = await _userManager.CreateAsync(e, p.Password);//asenkronik method ile hesap oluşturuyoruz
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login", new { area = "Employer" });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return View();
            }

            return View();
        }
    }
}
