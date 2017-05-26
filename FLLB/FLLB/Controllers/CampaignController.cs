using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FLLB.Models;
using FLLB.Repos;

namespace FLLB.Controllers
{
    public class CampaignController : BaseController
    {
        public ActionResult CampaignClick(string id)
        {
            FLLBRepos repo = new FLLBRepos();
           
            string redirectweb = repo.AddCampaignClick(id);
            if (!string.IsNullOrEmpty(redirectweb))
            {
                return Redirect(redirectweb);
            }
            
            return Redirect("https://floridalawyerbureau.com");
        }
 
        [HttpGet]
        public ActionResult Unsubscribe(string id)
        {
            FLLBRepos repo = new FLLBRepos();
            int intproid = FromHex(id);
            if (intproid > 0)
            {
                UnsubscribeVM model = new UnsubscribeVM()
                {
                    ProId = intproid,
                    AvailablesReasons = repo.GetUnsubscribeReasons()
                };
                return View(model);
            }
            return Redirect("https://floridalawyerbureau.com");
        }
        [HttpPost]
        public ActionResult Unsubscribe(UnsubscribeVM model)
        {
            FLLBRepos repo = new FLLBRepos();
            if (ModelState.IsValid)
            {

                if (repo.AddUnsubscritionByPatient(model.ProId, model.UnsubscriptionReasonId, model.EmailPro))
                    return View("UnsubscribeOK");
              
            }
            ModelState.AddModelError("EmailPro", "This Email is not in file");
            model.AvailablesReasons = repo.GetUnsubscribeReasons();
            return View(model);
          
        }
    }
}