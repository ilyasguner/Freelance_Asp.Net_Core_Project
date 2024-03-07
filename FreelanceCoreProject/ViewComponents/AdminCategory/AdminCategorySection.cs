using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.ViewComponents.AdminCategory
{
	public class AdminCategorySection:ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

		public IViewComponentResult Invoke()
		{
			var values = categoryManager.TGetList();
			return View(values);
		}
	}
}
