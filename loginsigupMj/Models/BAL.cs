using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace loginsigupMj.Models
{
    public class BAL
    {
        DAL dl = new DAL();


        DBconnection db = new DBconnection();

        public string Register(Register register)
        {
            return db.Register(register);
        }


        public string Login(Login log)
        {
            return db.Login(log);
        }


        public string LogApi(LoginApi logApi)
        {
            string response = dl.LoginApi(logApi);
            return response;
            //return dl.LoginApi(logApi);

        }


        public DataTable GetUserApi(int Id)
        {
            return dl.GetUser(Id) ;
        }
    }
}