using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using patternsLearning.Models;
using Newtonsoft.Json.Linq;

namespace patternsLearning.Controllers
{
    public class HomeController : Controller 
    {

        //sec_description - эт и есть краткая информация, шоб тебя
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BriefDescription() {
            siteDbEntities db;
            try
            {
                db = new siteDbEntities();
                JObject description = JObject.FromObject(
                    new
                    {
                        art =
                    from s in db.section
                    select new
                    {
                        sec_name = s.sec_name,
                        sec_description = s.sec_description,
                        sec_front_pic = s.sec_front_pic,
                        sec_back_pick = s.sec_back_pic
                    }
                    }
                        );
                ViewBag.descJSON = description;
                return PartialView();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView();
            }
        }
    }
}