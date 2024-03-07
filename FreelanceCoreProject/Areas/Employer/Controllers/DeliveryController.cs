using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("Employer/Delivery")]
    public class DeliveryController : Controller
    {
        OfferManager offerManager = new OfferManager(new EfOfferDal());
        private readonly UserManager<Employers> _userManager;

        public DeliveryController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        //kullanıcıya gelen iş teslimlerinin listelendiği asenkronik method
        [HttpGet]
        [Route("GiveDelivery")]
        public async Task<IActionResult> GiveDelivery()
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = offerManager.TGetList().Where(x => x.EmployerUserName == result.UserName && x.Delivery == true && x.Status==false).ToList();
            return View(values);
        }

        //gönderilen iş teslimini reddeden method
        [Route("Reddet/{id}")]
        public IActionResult Reddet(int id)
        {
            Offer offer = offerManager.TGetById(id);
            offer.Approval = 1;
            offerManager.TUpdate(offer);
            return RedirectToAction("ReceiverOfferList", "OfferFollow");
        }

        //bitirrilen işin alıcı tarafından onaylandığı ve işçi ile işveren arasında para transfrei olduğu asenkronik method
        [Route("Onayla/{id}")]
        public async Task<IActionResult> Onayla(int id)
        {
            Offer offer = offerManager.TGetById(id);
            offer.Status = true;

            var emloyer = await _userManager.FindByNameAsync(User.Identity.Name);
            emloyer.Money -= offer.Price;
            await _userManager.UpdateAsync(emloyer);

            var worke = await _userManager.FindByNameAsync(offer.WorkerUserName);
            worke.Money += offer.Price;
            await _userManager.UpdateAsync(worke);
            offerManager.TUpdate(offer);
            return RedirectToAction("ReceiverOfferList", "OfferFollow");
        }

        //kullanıcının gönderdiği iş teslimlerinin listelendiği asenkronik method 
        [HttpGet]
        [Route("SendDelivery")]
        public async Task<IActionResult> SendDelivery()
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = offerManager.TGetList().Where(x => x.WorkerUserName == result.UserName && x.Delivery == true && x.Status == true).ToList();
            return View(values);
        }

    }
}
