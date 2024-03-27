using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddTestimonial()
        {
            return View();
        }


        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddTestimonial(TblTestimonials testimonials)
        {
            db.TblTestimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(testimonial); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateTestimonial(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var skill = db.TblSkills.Find(id);
            return View(skill);
        }


        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skills)  // güncelleme işlemi yapmak için
        {
            var value = db.TblSkills.Find(skills.SkillId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.SkillName = skills.SkillName;  // parametrelerime atamalarımı yaptım
            value.Value = skills.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}