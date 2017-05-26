using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FLLB.Models;
using System.Data.Entity;

namespace FLLB.Repos
{
    public class FLLBRepos
    {
        private FLBAdminDevEntities db;
        protected FLBAdminDevEntities DB
        {
            get
            {
                if (db == null)
                    db = new FLBAdminDevEntities();
                return db;
            }
        }

        public ShortenURL GetCampaignLinkId(string linkid)
        {
            return  DB.ShortenURLs.Where(c => c.ShortenURL1 == linkid).FirstOrDefault();
        }


        public string AddCampaignClick(string linkid)
        {

            ShortenURL shortenurl = GetCampaignLinkId(linkid);
            if (shortenurl == null)
                return "";

            DB.Entry(shortenurl).State = EntityState.Modified;
            shortenurl.Count++;
            DB.SaveChanges();

            return shortenurl.URL;
           
        }

        public SelectListItem[] GetUnsubscribeReasons()
        {
            return DB.UnsubscribeReasons.Select(s => new SelectListItem
            {
                Text = s.UnsubscribeReasonName,
                Value = s.UnsubscribeReasonID.ToString(),
                Selected = false
            }).ToArray();
        }
        private bool ExistReasonsById(int reasonid)
        {
            return DB.UnsubscribeReasons.Any(r => r.UnsubscribeReasonID == reasonid);
        }
        private bool RealPro(int proid, string email)
        {
            KL_LawFinderEntities proentities = new KL_LawFinderEntities();
            return proentities.Pros.Where(pro => pro.Id == proid && pro.Email == email).Any();
        }
        public bool AddUnsubscritionByPatient(int proid, int reasonsid, string email)
        {

            if (ExistReasonsById(reasonsid) && RealPro(proid, email))
            {
                Unsubscription unsubscription = new Unsubscription()
                {
                    ProID = proid,
                    UnsubscribeOn = DateTime.Now,
                    UnsubcriptionReason = reasonsid,
                    Email = email
                };
                DB.Unsubscriptions.Add(unsubscription);
                DB.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
