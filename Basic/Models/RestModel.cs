using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic.Models
{
    public class RestModel
    {
        public Object data { get; set; }
        public Object other_data { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}