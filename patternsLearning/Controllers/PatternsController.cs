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
            siteDbEntities db;
            string pattern = "Паттерны проектирования";
            string solid = "Принципы SOLID";
            string otherPatt = "Другие паттерны проектирования";
            try
            {
                db = new siteDbEntities();
                ViewBag.patternJSON = PageStructure.getSection(db, pattern);
                ViewBag.solidJSON = PageStructure.getSection(db, solid);
                ViewBag.otherPatt = PageStructure.getSection(db, otherPatt);
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Articles() {
            return View();
        }
    }
}