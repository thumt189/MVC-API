using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic.Models
{
    public class APIProduct
    {
        public int id { get; set; }
        public int cat_id { get; set; }
        public string name { get; set; }
        public string cat_name { get; set; }
        public Nullable<int> price { get; set; }
        public string img { get; set; }
        public string note { get; set; }
        public int is_deleted { get; set; }
    }
}