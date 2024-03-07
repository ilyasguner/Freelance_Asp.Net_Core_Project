using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FreelanceCoreProject.Controllers
{
    public class InstagramFollowController : Controller
    {
		private readonly UserManager<Employers> _userManager;

		public InstagramFollowController(UserManager<Employers> userManager)
		{
			_userManager = userManager;
		}
		JobManager jobManager = new JobManager(new EfJobDal());
        public async Task<IActionResult> Index(int id)
        {
			var job = jobManager.TGetById(id);
			var worker =await _userManager.FindByNameAsync(User.Identity.Name);
            var employers = await _userManager.FindByNameAsync(job.EmployerUserName);
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("--headless"); // Tarayıcıyı başlatmadan arka planda çalıştırır

			IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));
            IWebElement login = driver.FindElement(By.CssSelector("._acan._acap._acas._aj1-._ap30"));

            userName.SendKeys("yazilimci20");
            password.SendKeys("214ibrhm20");
            login.Click();
			Thread.Sleep(5000);

			driver.Navigate().GoToUrl("https://www.instagram.com/yazilimci20/followers/");
			Thread.Sleep(5000);
			//IWebElement profil = driver.FindElement(By.CssSelector("#mount_0_0_C3 > div > div > div.x9f619.x1n2onr6.x1ja2u2z > div > div > div.x78zum5.xdt5ytf.x1t2pt76.x1n2onr6.x1ja2u2z.x10cihs4 > div.x9f619.xvbhtw8.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1uhb9sk.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1qughib > div.x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1.xixxii4.x1ey2m1c.xg7h5cd.x80663w.xh8yej3.xhtitgo.x6w1myc.x1jeouym > div > div > div > div > div > div:nth-child(6) > div > span > div > a"));
			//profil.Click();

			//IWebElement followers = driver.FindElement(By.CssSelector("#mount_0_0_nL > div > div > div.x9f619.x1n2onr6.x1ja2u2z > div > div > div.x78zum5.xdt5ytf.x1t2pt76.x1n2onr6.x1ja2u2z.x10cihs4 > div.x9f619.xvbhtw8.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1uhb9sk.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1qughib > div.x1gryazu.xh8yej3.x10o80wk.x14k21rp.x17snn68.x6osk4m.x1porb0y > div:nth-child(2) > section > main > div > ul > li:nth-child(2) > a"));
			//followers.Click();

			IReadOnlyCollection<IWebElement> followers = driver.FindElements(By.CssSelector("._ap3a._aaco._aacw._aacx._aad7._aade"));

			foreach (IWebElement follower in followers)
			{
				
				if (follower.Text == worker.UserName)
				{
					worker.Money += job.Price;
					employers.Money -= job.Price;
					await _userManager.UpdateAsync(worker);
					await _userManager.UpdateAsync(employers);					
				}
			}
			return RedirectToAction("Index", "HomePage", new { area = "Employer" });
		}
    }
}
