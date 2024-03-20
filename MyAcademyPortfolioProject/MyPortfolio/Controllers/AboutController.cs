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

        // db nesnesi aracılığı ile listeleme işlemini burada yaptık, View içerisinde bu listeleme işlemini görmek istersem:
        // 1- index'e gelip go to view dersem hakkımda sayfasının kod içeriğe gider (html sayfası)
        // 2- ilgili sayfada (html sayfası) en başa @model List<MyPortfolio.Models.TblAbouts> ekleriz. 

    }
}