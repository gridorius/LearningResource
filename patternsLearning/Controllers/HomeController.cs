﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }

        public JArray BriefDescription()
        {
            JArray list = new JArray();
            try
            {
                using (siteDbEntities1 db = new siteDbEntities1())
                {
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
                            sec_back_pic = s.sec_back_pic,
                            sec_controller = s.sec_controller

                        },
                        }
            );
                    list.Add(description);
                    list.Add(PageStructure.getListSource());
                    return list;
                }

            }
            catch (Exception ex)
            {
                list.Add(new JObject(
                    new JProperty("error", ex.Message)));
                return list;
            }
        }
    }
}