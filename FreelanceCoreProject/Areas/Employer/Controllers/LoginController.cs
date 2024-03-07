using EntityLayer.Concrete;
using FreelanceCoreProject.Areas.Employer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("Employer/[Controller]/[action]")]
    
    public class LoginController : Controller
    {
        private readonly SignInManager<Employers> _signInManager;

        public LoginController(SignInManager<Employers> signInManager)
        {
            _signInManager = signInManager;
        }

        //tasarım sayfamız 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //giriş yapmak için kullandığımız asenkronik method
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index","HomePage", new { area = "Employer" });
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı Adı ve Şifre");
                }
                
            }
            return View();
        }

        //çıkış methodumuz
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
