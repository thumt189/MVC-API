using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic.Models
{
    public class APICategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<byte> is_deleted { get; set; }
    }
}