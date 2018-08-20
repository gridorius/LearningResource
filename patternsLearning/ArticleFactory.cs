using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using patternsLearning.Models;
using System.Web.Mvc;

namespace patternsLearning
{
    public interface IArticleFactory
    {
        JObject getJSON(siteDbEntities1 db, string artName);
    }

    public class PattentFactory : IArticleFactory {

        public JObject getJSON(siteDbEntities1 db, string artName) {
            return JObject.FromObject(new {
               article = from a in db.article
                where a.art_name==artName
                select new
                {
                    art_name = a.art_name,
                    art_description = a.art_description,
                    base_part = from bp in db.base_part
                                where bp.art_id == a.art_id
                                select new
                                {
                                    base_part_name = bp.base_part_name,
                                    base_part_description = bp.base_part_description,
                                    base_part_pic = bp.base_part_pic,
                                    base_part_info = bp.base_part_info
                                },
                    art_motivation = a.art_motivation,
                    sample_part = from sp in db.sample_part
                                  where sp.art_id == a.art_id
                                  select new
                                  {
                                      sample_part_name = sp.sample_part_name,
                                      sample_part_description = sp.sample_part_description,
                                      sample_part_pic = sp.sample_part_pic,
                                      sample_part_info = sp.sample_part_info,
                                      sample_part_code = sp.sample_part_code,
                                      sample_part_gitref = sp.sample_part_gitref
                                  },
                    art_note = a.art_note,
                    art_pic = a.art_pic
                    
                } });
        }
    }

    public class AlgorithmFactory : IArticleFactory {

        public JObject getJSON(siteDbEntities1 db, string artName) {
            return new JObject();
        }
    }
}