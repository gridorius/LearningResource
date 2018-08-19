using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using patternsLearning.Models;

namespace patternsLearning.Controllers
{
    public class PatternsController : Controller
    {
        // GET: Patterns
        public ActionResult Index()
        {
            return View();
        }

        //ya pidoras
        public ActionResult PatternPageStructure()
        {
            siteDbEntities1 db;
            string secName = "Паттерны проектирования";
            try
            {
                db = new siteDbEntities1();
                ViewBag.Json = PageStructure.getSection(db, secName);
                return PartialView();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView();
            }
        }

        public ActionResult Articles()
        {
            return PartialView();
        }
    }
}