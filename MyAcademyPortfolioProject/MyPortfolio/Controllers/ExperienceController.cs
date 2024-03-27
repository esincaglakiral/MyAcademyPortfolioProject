using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblExperiences.ToList();
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddExperience()
        {
            return View();
        }


        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddExperience(TblExperiences experiences)
        {
            db.TblExperiences.Add(experiences); //db nesnesine TblExperiences tablosundan experiences parametresini add metoduyla verdik yani ekleme yaptıkça tabloya da eklicek
            db.SaveChanges(); // bunu yapmazsak ekleme işlemi gerçekleşmez
            return RedirectToAction("Index"); // index action'una gönderir
        }

        public ActionResult DeleteExperience(int id)
        {
            var experience = db.TblExperiences.Find(id); //İd den gelen değerle birlikte TblExperiences tablosundan gelen değeri buldu ve experience değişkenine atadı
            db.TblExperiences.Remove(experience); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateExperience(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var experience = db.TblExperiences.Find(id);
            return View(experience);
        }


        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences experiences)  // güncelleme işlemi yapmak için
        {
            var value = db.TblExperiences.Find(experiences.ExperienceId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.StartYear = experiences.StartYear;  // parametrelerime atamalarımı yaptım
            value.EndYear = experiences.EndYear;
            value.Title = experiences.Title;
            value.Description = experiences.Description;
            value.Company = experiences.Company;
            value.Location = experiences.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}