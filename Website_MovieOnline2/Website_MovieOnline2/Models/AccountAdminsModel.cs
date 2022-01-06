using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MovieOnline2.Models.ModelPhim1;

namespace Website_MovieOnline2.Models
{
    public class AccountAdminsModel
    {
        private Website_MovieOnline2_DbContext context = null;

        public AccountAdminsModel()
        {
            context = new Website_MovieOnline2_DbContext();
        }

        public bool Login(string username, string password)
        {
            object[] sqlParams = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Admins_Login @Username,@Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}