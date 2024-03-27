using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblServices.ToList(); // TblServices tablosundaki değerleri ToList metoduyla listelemek için values değerine atadık
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddService()
        {
            return View();
        }

        public ActionResult MakeActive(int id)
        {
            // var value = db.TblServices.FirstOrDefault(x=>x.ServiceId == id);

            var value = db.TblServices.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MakePassive(int id)
        {
            // var value = db.TblServices.FirstOrDefault(x=>x.ServiceId == id);

            var value = db.TblServices.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddService(TblServices services)
        {
            db.TblServices.Add(services); //db nesnesine TblServices tablosundan services parametresini add metoduyla verdik yani ekleme yaptıkça tabloya da eklicek
            db.SaveChanges(); // bunu yapmazsak ekleme işlemi gerçekleşmez
            return RedirectToAction("Index"); // index action'una gönderir
        }

        public ActionResult DeleteService(int id)
        {
            var service = db.TblServices.Find(id); //İd den gelen değerle birlikte TblServices tablosundan gelen değeri buldu ve service değişkenine atadı
            db.TblServices.Remove(service); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateService(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var service = db.TblServices.Find(id);
            return View(service);
        }


        [HttpPost]
        public ActionResult UpdateService(TblServices services)  // güncelleme işlemi yapmak için
        {
            var value = db.TblServices.Find(services.ServiceId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.Icon = services.Icon;  // parametrelerime atamalarımı yaptım
            value.Title = services.Title;
            value.Description = services.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}