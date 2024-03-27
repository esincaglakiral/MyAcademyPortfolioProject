using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  // db nesnesi türetiyoruz
        public ActionResult Index()
        {
            var values = db.TblTeams.ToList();
            return View(values); // değeri döndürmek için
        }

        [HttpGet]  // Sadece sayfayı görüntüleriz
        public ActionResult AddTeam()
        {
            return View();
        }


        [HttpPost] //içerisinde form oluştururuz ve butona tıkladığımız zaman post metodu çalışıcaktır.
        public ActionResult AddTeam(TblTeams teams)
        {
            db.TblTeams.Add(teams);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteMessage(int id)
        {
            var team = db.TblTeams.Find(id);
            db.TblTeams.Remove(team); // bulduğu değeri Remove metodu ile siler yani önce id den gelen değeri bulur sonra siler
            db.SaveChanges();  // işlemi kaydediyoruz
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateTeam(int id) // önce id ye bağlı değerleri getirmesi için (formu açınca o idye bağlı değerlerin gelmesi) httpget metodu 
        {
            var team = db.TblTeams.Find(id);
            return View(team);
        }


        [HttpPost]
        public ActionResult UpdateTeam(TblTeams teams)  // güncelleme işlemi yapmak için
        {
            var value = db.TblTeams.Find(teams.TeamId); // value değişkenine aboutid den gelen değerleri bulup ata
            value.ImageUrl = teams.ImageUrl;  // parametrelerime atamalarımı yaptım
            value.NameSurname = teams.NameSurname;
            value.Title = teams.Title;
            value.Decription = teams.Decription;
            value.TwitterUrl = teams.TwitterUrl;
            value.FacebookUrl = teams.FacebookUrl;
            value.LinkedinUrl = teams.LinkedinUrl;
            value.InstagramUrl = teams.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}