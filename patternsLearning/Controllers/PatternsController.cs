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

        public JObject PatternPageStructure()
        {
            string secName = "Паттерны проектирования";
            try
            {
                return PageStructure.getSection(secName);
            }
            catch (Exception ex)
            {
                return new JObject (
                    new JProperty("error",ex.Message));
            }
        }

        public JObject Articles(ArticleModel art)
        {
            string artName;
            PattentFactory factory;
            try
            {
                artName = art.artName;
                factory = new PattentFactory();
                return factory.getJSON(artName);
            }
            catch (Exception ex) {
                return new JObject(
                    new JProperty("error", ex.Message));
            }
        }
    }
}