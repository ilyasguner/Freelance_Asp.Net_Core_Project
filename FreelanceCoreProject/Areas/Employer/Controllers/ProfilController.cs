using EntityLayer.Concrete;
using FreelanceCoreProject.Areas.Employer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Authorize]
    [Area("Employer")]
    [Route("Employer/[Controller]/[action]")]
    public class ProfilController : Controller
    {
        public readonly UserManager<Employers> _userManager;

        public ProfilController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.UserName = values.UserName;
            model.Email = values.Email;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            if(ModelState.IsValid)
            {
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				if (p.Image != null)
				{   //resim yolunu alıp kaydetme kodları
					var resource = Directory.GetCurrentDirectory();
					var extension = Path.GetExtension(p.Image.FileName);
					var imagename = Guid.NewGuid() + extension;
					var savelocation = resource + "/wwwroot/UserImage/" + imagename;
					var stream = new FileStream(savelocation, FileMode.Create);
					await p.Image.CopyToAsync(stream);
					user.ImageUrl = imagename;
				}
				user.UserName = p.UserName;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Default");
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
