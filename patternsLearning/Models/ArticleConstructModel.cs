using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace patternsLearning.Models
{
    public class ArticleConstructModel
    {
        //я тут хероту какую-то напишу пока, сам смотри, пойдет для вьюшки или нет
        public string art_name { get; set; }
        public string art_description { get; set; }
        public string art_motivation { get; set; }
        public string art_note { get; set; }
        public int cat_name { get; set; }
        public string art_pic { get; set; }
    }
}