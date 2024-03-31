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

        public ActionResult MakeActive(int id)
        {
            // var value = db.TblServices.FirstOrDefault(x=>x.ServiceId == id);

            var value = db.TblTestimonials.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
            // AJAX çağrısı yapılarak UI'da ilgili referansın durumu güncelleniyor
            return Json(new { success = true, status = "active" });

        }

        public ActionResult MakePassive(int id)
        {
            // var value = db.TblServices.FirstOrDefault(x=>x.ServiceId == id);

            var value = db.TblTestimonials.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
            // AJAX çağrısı yapılarak UI'da ilgili referansın durumu güncelleniyor
            return Json(new { success = true, status = "passive" });

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
            var testimonial = db.TblTestimonials.Find(id);
            return View(testimonial);
        }


        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials testimonials)  // güncelleme işlemi yapmak için
        {
            var value = db.TblTestimonials.Find(testimonials.TestimonialId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.ImageUrl = testimonials.ImageUrl;  // parametrelerime atamalarımı yaptım
            value.Comment = testimonials.Comment;
            value.NameSurname = testimonials.NameSurname;
            value.Title = testimonials.Title;
            value.Status = testimonials.Status;
            value.CommentDate = testimonials.CommentDate;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}