using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using patternsLearning.Models;
using System.Web.Mvc;

namespace patternsLearning
{
    public static class PageStructure
    {
        public static JObject getSection(siteDbEntities1 db, string secName ) {
            db = new siteDbEntities1();
            var section = db.section.Where(s => s.sec_name == secName).Single();
            JObject sectionJSON = JObject.FromObject(new
            {
                section = new
                {
                    sec_name = section.sec_name,
                    sec_description = section.sec_description,
                    category = from c in db.category
                               where c.sec_id == section.sec_id
                               select new
                               {
                                   cat_name = c.cat_name,
                                   cat_description = c.cat_description,
                                   article = from a in db.article
                                             where a.cat_id == c.cat_id
                                             select new
                                             {
                                                 art_name = a.art_name,
                                                 art_description = a.art_description
                                             }
                               }
                }
            });
            return sectionJSON;
        }
    }
}