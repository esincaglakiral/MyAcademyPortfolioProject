using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList(); 
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddSocialMedia()
        {
            return View();
        }


        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddSocialMedia(TblSocialMedias socialmedias)
        {
            db.TblSocialMedias.Add(socialmedias); //db nesnesine TblSocialMedias tablosundan socialmedias parametresini add metoduyla verdik yani ekleme yaptıkça tabloya da eklicek
            db.SaveChanges(); // bunu yapmazsak ekleme işlemi gerçekleşmez
            return RedirectToAction("Index"); // index action'una gönderir
        }


        public ActionResult DeleteSocialMedia(int id)
        {
            var socialmedia = db.TblSocialMedias.Find(id); //İd den gelen değerle birlikte TblSocialMedias tablosundan gelen değeri buldu ve socialmedia değişkenine atadı
            db.TblSocialMedias.Remove(socialmedia); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateSocialMedia(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var socialmedia = db.TblSocialMedias.Find(id);
            return View(socialmedia);
        }


        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialmedias)  // güncelleme işlemi yapmak için
        {
            var value = db.TblSocialMedias.Find(socialmedias.SocialMediaId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.SocialMediaName = socialmedias.SocialMediaName;  // parametrelerime atamalarımı yaptım
            value.Url = socialmedias.Url;
            value.Icon = socialmedias.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}