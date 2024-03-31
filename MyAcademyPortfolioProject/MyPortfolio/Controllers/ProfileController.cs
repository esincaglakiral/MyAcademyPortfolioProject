using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        // GET: Profile
        public ActionResult Index()
        {
            var values = db.TblAdmins.ToList(); // TblContacts tablosundaki değerleri ToList metoduyla listelemek için values değerine atadık
            return View(values); // değeri döndürmek için
        }

        [AllowAnonymous] // Bu attribute, belirli action metodlarını yetkilendirme gereksinimlerinden muaf tutar
        public ActionResult UpdateProfile(int id)
        {
            var profile = db.TblAdmins.Find(id);
            if (profile == null)
            {
                return HttpNotFound(); // Eğer profil bulunamazsa HTTP 404 döndür
            }
            return View(profile);
        }


        [HttpPost]
        public ActionResult UpdateProfile(TblAdmins updatedProfile)
        {
            var existingProfile = db.TblAdmins.Find(updatedProfile.AdminId);
            if (existingProfile == null)
            {
                return HttpNotFound(); // Profil bulunamazsa HTTP 404 döndür
            }

            existingProfile.UserName = updatedProfile.UserName;
            existingProfile.Password = updatedProfile.Password;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }

}
