using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace loginsigupMj.Models
{
    public class DBconnection
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CON"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;


        //For MVC Controller
        public string Register(Register register)
        {
            try
            {


                //cmd = new SqlCommand("Masterinsertupdatedelete", con);
                cmd = new SqlCommand("OTOInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();


                //cmd.Parameters.Add("@StatementType", SqlDbType.VarChar, 100).Value = "Insert";
                //cmd.Parameters["@FirstName"].Value = register.FirstName;
                //cmd.Parameters["@LastName"].Value = register.LastName;
                //cmd.Parameters["@Email"].Value = register.Email;
                //cmd.Parameters["@Gender"].Value = register.Gender;
                //cmd.Parameters["@Password"].Value = register.Password;
                //cmd.Parameters["@Active"].Value = register.Active;


                cmd.Parameters.AddWithValue("@FirstName", register.FirstName);
                cmd.Parameters.AddWithValue("@LastName", register.LastName);
                cmd.Parameters.AddWithValue("@Email", register.Email);
                cmd.Parameters.AddWithValue("@Gender", register.Gender);
                cmd.Parameters.AddWithValue("@Password", register.Password);
                cmd.Parameters.AddWithValue("@Active", register.Active);




                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return "Registration successful";

                }
                else
                {
                    return "Registration Faild";
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public string Login(Login login)
        {
            da = new SqlDataAdapter("Log_In", con);
            da = new SqlDataAdapter("Select 1 from Register Where Email='"+login.Email+ "' And Password='" + login.Password+"' ", con);
            

            dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count>0)
            {

                return "Logged In";

            }
            else
            {
                return "Login Failed";
            }

        }
    }
}