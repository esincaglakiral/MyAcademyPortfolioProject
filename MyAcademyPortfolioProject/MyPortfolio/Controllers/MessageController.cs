using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddMessage()
        {
            return View();
        }


        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages); 
            db.SaveChanges(); 
            return RedirectToAction("Index"); 
        }


        public ActionResult DeleteMessage(int id)
        {
            var message = db.TblMessages.Find(id); 
            db.TblMessages.Remove(message); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateMessage(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var message = db.TblMessages.Find(id);
            return View(message);
        }


        [HttpPost]
        public ActionResult UpdateMessage(TblMessages messages)  // güncelleme işlemi yapmak için
        {
            var value = db.TblMessages.Find(messages.MessageId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.Name = messages.Name;  // parametrelerime atamalarımı yaptım
            value.Email = messages.Email;
            value.Subject = messages.Subject;
            value.MessageContent = messages.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}