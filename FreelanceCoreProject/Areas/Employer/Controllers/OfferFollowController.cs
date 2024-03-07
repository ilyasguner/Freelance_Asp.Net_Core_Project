using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceCoreProject.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("Employer/OfferFollow")]
    public class OfferFollowController : Controller
    {
        OfferManager offerManager = new OfferManager(new EfOfferDal());
        
        private readonly UserManager<Employers> _userManager;

        public OfferFollowController(UserManager<Employers> userManager)
        {
            _userManager = userManager;
        }

        //gönderilen tekliflerin listesi 
        [Route("GiveOfferList")]
        public async Task<IActionResult> GiveOfferList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = offerManager.TGetList().Where(x => x.WorkerUserName == user.ToString()).ToList();
            return View(values);
        }

        //alınan tekliflerin listesi
        [Route("ReceiverOfferList")]
        public async Task<IActionResult> ReceiverOfferList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = offerManager.TGetList().Where(x => x.EmployerUserName == user.ToString() && x.Approval==0).ToList();
            return View(values);
        }

        [Route("RejectOffer/{id}")]
        public IActionResult RejectOffer(int id)
        {
            Offer offer = offerManager.TGetById(id);
            offer.Approval = 2;
            offerManager.TUpdate(offer);
            return RedirectToAction("ReceiverOfferList","OfferFollow");
        }

        [Route("ApproveOffer/{id}")]
        public IActionResult ApproveOffer(int id)
        {
            Offer offer = offerManager.TGetById(id);
            offer.Approval = 1;
            offerManager.TUpdate(offer);
            return RedirectToAction("ReceiverOfferList","OfferFollow");
        }

        //Gelen tekliflerin kabul edildiği
        [Route("GiveDelivery/{id}")]
        public IActionResult GiveDelivery(int id)
        {
            Offer offer = offerManager.TGetById(id);
            offer.Delivery = true;
            offerManager.TUpdate(offer);
            return RedirectToAction("ReceiverOfferList", "OfferFollow");
        }

    }
}
