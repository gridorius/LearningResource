using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace patternsLearning.Models
{
    public class SamplePartConstructModel
    {
        //пример
        public bool sample_need { get; set; } // эт для чекбокса другого
        public string sample_part_name { get; set; }
        public string sample_part_description { get; set; }
        public string sample_part_pic { get; set; }
        public string sample_part_info { get; set; }
        public string sample_part_code { get; set; }
        public string sample_part_gitref { get; set; }
    }
}