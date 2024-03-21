using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList(); // tblabouts tablosundaki değerleri ToList metoduyla listelemek için values değerine atadık
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddAbout(TblAbouts abouts)
        {
            db.TblAbouts.Add(abouts); //db nesnesine tblabouts tablosundan abouts parametresini add metoduyla verdik yani ekleme yaptıkça tabloya da eklicek
            db.SaveChanges(); // bunu yapmazsak ekleme işlemi gerçekleşmez
            return RedirectToAction("Index"); // index action'una gönderir
        }

        public ActionResult DeleteAbout(int id)
        {
           var about =  db.TblAbouts.Find(id); //İd den gelen değerle birlikte tblabout tablosundan gelen değeri buldu ve about değişkenine atadı
           db.TblAbouts.Remove(about); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
           db.SaveChanges();  // işlemi kaydediyoruz
           return RedirectToAction("Index");
        }


        [HttpGet]

        public ActionResult UpdateAbout(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }


        [HttpPost]
        public ActionResult UpdateAbout(TblAbouts abouts)  // güncelleme işlemi yapmak için
        {
            var value = db.TblAbouts.Find(abouts.AboutId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.ImageUrl = abouts.ImageUrl;  // parametrelerime atamalarımı yaptım
            value.Title = abouts.Title;
            value.Description = abouts.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}

// db nesnesi aracılığı ile listeleme işlemini burada yaptık, View içerisinde bu listeleme işlemini görmek istersem:
// 1- index'e gelip go to view dersem hakkımda sayfasının kod içeriğe gider (html sayfası)
// 2- ilgili sayfada (html sayfası) en başa @model List<MyPortfolio.Models.TblAbouts> ekleriz. 
// 3- Controller tarafında değişkenimize (values) liste türünde bir değer atadığımız için view tarafında da
// modelimizi liste türünde ( @model List<MyPortfolio.Models.TblAbouts> ) veririz.