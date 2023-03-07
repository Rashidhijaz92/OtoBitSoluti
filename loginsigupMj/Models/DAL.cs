using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace loginsigupMj.Models
{
    public class DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CON"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;

        //for API Controller


        public string LoginApi(LoginApi logApi)
        {
            //da = new SqlDataAdapter("Log_In", con);
            da = new SqlDataAdapter("Select * from Register Where Email='" + logApi.username + "' And Password='" + logApi.password + "' ", con);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                return "Logged In";

            }
            else
            {
                return "Login Failed";
            }
        }

        public class Register
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Password { get; set; }
            public int Active { get; set; }
        }


        public DataTable GetUser(int Id)
       {
                 cmd = new SqlCommand("GedetailsbyID", con);

                cmd.CommandType = CommandType.StoredProcedure;

                

                cmd.Parameters.AddWithValue("@id", Id);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataSet ds = new DataSet("Registertbl");

                da.Fill(ds);

                DataTable dt = ds.Tables[0];


                Register model = new Register();

                model.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                model.FirstName = dt.Rows[0]["FirstName"].ToString();
                model.LastName = dt.Rows[0]["LastName"].ToString() ;
                model.Gender =dt.Rows[0]["Gneder"].ToString()  ;
                model.Email =dt.Rows[0]["Email"].ToString()  ;
                model.Active =Convert.ToInt32(dt.Rows[0]["Active"] );

                return dt;
        }
            

        
    }
}