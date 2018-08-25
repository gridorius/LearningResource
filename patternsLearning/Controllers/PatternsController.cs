using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using patternsLearning.Models;
using Newtonsoft.Json.Linq;

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
        public JObject PatternPageStructure()
        {
            siteDbEntities1 db;
            string secName = "Паттерны проектирования";
            try
            {
                db = new siteDbEntities1();
                return PageStructure.getSection(db, secName);
            }
            catch (Exception ex)
            {
                return new JObject (
                    new JProperty("error",ex.Message));
            }
        }

        public JObject Articles(ArticleModel art)
        {
            siteDbEntities1 db;
            string artName;
            PattentFactory factory;
            try
            {
                db = new siteDbEntities1();
                artName = art.artName;
                factory = new PattentFactory();
                return factory.getJSON(db, artName);
            }
            catch (Exception ex) {
                return new JObject(
                    new JProperty("error", ex.Message));
            }
        }
    }
}