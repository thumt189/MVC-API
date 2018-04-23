using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic.code
{
    [Serializable]
    public class UserSession
    {
        public string username { get; set; }
        public string name { get; set; }
    }
}