using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace patternsLearning.Models
{
    public class BasePartConstructModel
    {
        //а тут база
        public bool base_need { get; set; } // эт для чекбокса
        public string base_part_name { get; set; }
        public string base_part_description { get; set; }
        public string base_part_pic { get; set; }
        public string base_part_info { get; set; }
    }
}