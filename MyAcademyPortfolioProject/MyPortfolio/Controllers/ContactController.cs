using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList(); // TblContacts tablosundaki değerleri ToList metoduyla listelemek için values değerine atadık
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddContact()
        {
            return View();
        }


        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddContact(TblContacts contacts)
        {
            db.TblContacts.Add(contacts); //db nesnesine tblabouts tablosundan abouts parametresini add metoduyla verdik yani ekleme yaptıkça tabloya da eklicek
            db.SaveChanges(); // bunu yapmazsak ekleme işlemi gerçekleşmez
            return RedirectToAction("Index"); // index action'una gönderir
        }

        public ActionResult DeleteContact(int id)
        {
            var contact = db.TblContacts.Find(id); //İd den gelen değerle birlikte tblabout tablosundan gelen değeri buldu ve about değişkenine atadı
            db.TblContacts.Remove(contact); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateContact(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var contact = db.TblContacts.Find(id);
            return View(contact);
        }


        [HttpPost]
        public ActionResult UpdateContact(TblContacts contacts)  // güncelleme işlemi yapmak için
        {
            var value = db.TblContacts.Find(contacts.ContactId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.NameSurname = contacts.NameSurname;  // parametrelerime atamalarımı yaptım
            value.Adress = contacts.Adress;
            value.Phone = contacts.Phone;
            value.Email = contacts.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}