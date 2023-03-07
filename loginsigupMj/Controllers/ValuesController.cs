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
        public object GetToken()
        {
            string key = "my_secret_key_1234";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var permClaims = new List<Claim>();

            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("", "1"));
            permClaims.Add(new Claim("", "1"));
            permClaims.Add(new Claim("", "1"));
            permClaims.Add(new Claim("ABCD@gmail.com", "123"));


            var token = new JwtSecurityToken(issuer,
                issuer,
                permClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential);

            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new  { data=jwt_token };

            

        }

        //Get Log in through web api
        [Route("api/values/GetLogin")]
        [HttpPost]
        public string GetLogin(LoginApi logapi)
        {
            BAL bl = new BAL();

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

        [Route("api/values/PostUpdateUser")]


        // complex object with single row. - save employee
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
                    return "Data Update Succesfullu";
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
