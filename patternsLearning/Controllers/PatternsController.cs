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
            int secID = 1;
            try
            {
                return PageStructure.getSection(secID);
            }
            catch (Exception ex)
            {
                return new JObject (
                    new JProperty("error",ex.Message));
            }
        }

        public JObject Articles(ArticleModel art)
        {
            int artId;
            PattentFactory factory;
            try
            {
                artId = art.artId;
                factory = new PattentFactory();
                return factory.getJSON(artId);
            }
            catch (Exception ex) {
                return new JObject(
                    new JProperty("error", ex.Message));
            }
        }
    }
}