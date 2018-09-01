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
        // get langing structure
        public static JObject getSection(int secId)
        {
            using (siteDbEntities1 db = new siteDbEntities1())
            {
                var section = db.section.Where(s => s.sec_id == secId).Single();
                JObject sectionJSON = JObject.FromObject(new
                {
                    section = new
                    {
                        secId = secId,
                        sec_name = section.sec_name,
                        sec_description = section.sec_description,
                        category = from c in db.category
                                   where c.sec_id == section.sec_id
                                   select new
                                   {
                                       cat_id = c.cat_id,
                                       cat_name = c.cat_name,
                                       cat_description = c.cat_description,
                                       article = from a in db.article
                                                 where a.cat_id == c.cat_id
                                                 select new
                                                 {
                                                     art_id=a.art_id,
                                                     art_name = a.art_name,
                                                     art_description = a.art_description
                                                 }
                                   }
                    }
                });
                return sectionJSON;
            }
        }

        // get list of all sources
        public static JObject getListSource() {
            using (siteDbEntities1 db = new siteDbEntities1()) {
                return JObject.FromObject(
                    new {
                        list = from l in db.list_source
                        orderby l.sec_id, l.list_type
                        select new {
                            list_name=l.list_name,
                            list_author=l.list_author,
                            list_type = l.list_type,
                            list_url=l.list_url
                        }
            }
                    );
            }
        }

        // get list of a concrete section
        public static JObject getListSource(int secId) {
            using (siteDbEntities1 db = new siteDbEntities1()) {
                return JObject.FromObject(new {
                    list = from l in db.list_source
                           where l.sec_id == secId
                           orderby l.list_type
                           select new {
                               list_name = l.list_name,
                               list_author = l.list_author,
                               list_type = l.list_type,
                               list_url = l.list_url
                           }
                });
            }
        }
    }
}