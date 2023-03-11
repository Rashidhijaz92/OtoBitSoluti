using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using loginsigupMj.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace loginsigupMj.Controllers
{
    public class ValuesController : ApiController
    {
        BAL bl = new BAL();

        [HttpGet]
        public object GetToken(Register register)
        {
            //public object GetToken(string username,string password)
            //{
            string key = "my_secret_key_1234";
            var issuer = "http://localhost:52981";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();

            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("Valid", "1"));
            permClaims.Add(new Claim("UserId", "1"));
            permClaims.Add(new Claim("Email", "ABCD@gmail.com"));
            permClaims.Add(new Claim("PassWord", "123"));
            //permClaims.Add(new Claim("Email", register.Email));
            //permClaims.Add(new Claim("FirtName",register.FirstName));
            //permClaims.Add(new Claim("Gender", register.Gender)); 
            // permClaims.Add(new Claim(Logapi.username, Logapi.password)); 
            //permClaims.Add(new Claim(username, password)); 


            var token = new JwtSecurityToken(issuer,
                issuer,
                permClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential);

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new  { data=jwt_token };
        }

        [HttpPost]
        public string GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";

            }
            else
            {
                return "Invalid";
            }
        }


        [Authorize]
        [HttpPost]
        public string GetName2()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var Name = claims.Where(p => p.Type == "Name").FirstOrDefault()?.Value;
                }
                return "Valid";

            }
            else
            {
                return "Invalid";
            }
        }


        //Get Log in through web api
       
        [Route("api/values/GetLogin")]
        [HttpPost]
        public string GetLogin(LoginApi logapi)
        {
           

            string response = bl.LogApi(logapi);
            return response;

        }

        //Get registered through web api

        [Route("api/values/GetRegister")]

        [HttpPost]
        public string GetRegister(Register registerApi)
        {

            string response = bl.Register(registerApi);
            return response;
        }

        //Get Data  through web api

        [Route("api/values/GetUserApi")]
        public DataTable GetUserApi(int Id)
        {
            DataTable dt = new DataTable();
            dt = bl.GetUserApi(Id);     
            return dt;

        }

        //update data 




        // complex object with single row. - save employee'
        [Route("api/Values/PostUpdateUser")]
        [HttpPost]
        public string PostUpdateUser([FromUri] int Id, [FromBody] Register model)
        {
            try
            {
                // connectoin string 
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CON"].ConnectionString);
                SqlCommand cmd = null;
                // it's used to connect to sql server.. make sure to pass connecttion string variable              
                cmd = new SqlCommand("UpdateData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Active", model.Active);

                con.Open();
                int noOfRowAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (noOfRowAffected > 0)
                {
                    return "Data Update Succesfull";
                }
                else
                {
                    return "Data Failed to Update";
                }
            }
            catch (Exception ex)
            {

            }
            string response = "";

            return response;
        }

    }
}
