using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Basic.Models
{
    public class AccountModel
    {
        private basicEntities db = null;

        public AccountModel()
        {
            db = new basicEntities();
        }
        public bool Login(string username, string password)
        {
            var sqlParams = new SqlParameter[]{
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
            };
            var res = db.Database.SqlQuery<bool>("login @username,@password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}