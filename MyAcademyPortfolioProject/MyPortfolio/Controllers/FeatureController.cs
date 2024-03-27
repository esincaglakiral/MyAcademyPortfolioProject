using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  //db nesnesi türetiriz
        public ActionResult Index()
        {
            var values = db.TblFeatures.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddFeature(TblFeatures features)
        {
       
            db.TblFeatures.Add(features);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));  // return RedirectToAction("Index"); ifadesiyle bu ifade aynı anlamda ikisi de kullanılabilir.
        }


        public ActionResult DeleteFeature(int id)
        {
            var feature = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(feature);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)  // sadece id ye bağlı değerlerimizi getirdik
        {
            var value = db.TblFeatures.Find(id); // var category = db.TblCategories.FirstOrDefault(x => x.CategoryId == id); de diyebilirdik aynı işlem
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeatures feature)  // gelen değerlerde güncelleme işlemi yapması için gerekli metodu yazdık
        {
            var value = db.TblFeatures.Find(feature.FeatureId);
            value.NameSurname = feature.NameSurname;
            value.Title = feature.Title;
            value.ImageUrl = feature.ImageUrl;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}