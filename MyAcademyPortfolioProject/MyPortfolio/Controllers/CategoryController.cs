using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
       MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();  //db nesnesi türetiriz
        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategories categories) 
        {
            db.TblCategories.Add(categories);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));  // return RedirectToAction("Index"); ifadesiyle bu ifade aynı anlamda ikisi de kullanılabilir.
        }

        public ActionResult DeleteCategory(int id) 
        {
            var category = db.TblCategories.Find(id); 
            db.TblCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)  // sadece id ye bağlı değerlerimizi getirdik
        {
            var value = db.TblCategories.Find(id); // var category = db.TblCategories.FirstOrDefault(x => x.CategoryId == id); de diyebilirdik aynı işlem
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategories category)  // gelen değerlerde güncelleme işlemi yapması için gerekli metodu yazdık
        {
            var value = db.TblCategories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
} 