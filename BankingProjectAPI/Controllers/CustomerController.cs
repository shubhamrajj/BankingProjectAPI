using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using DAL.Models;
using Microsoft.IdentityModel.Tokens;

namespace BankingProjectAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        [Route("api/GetAllProfiles")]
        public List<Customer> GetAllCustomer()
        {
            return DAL.Models.CustomerModel.GetAllCustomerProfile();
        }

        [Route("api/GetCustomer")]
        public Customer GetCustomer(int id)
        {
            return DAL.Models.CustomerModel.GetCustomerProfile(id);

        }

        // POST: api/Customer
        [Route("api/CreateCustomer")]
        public void CreateCustomer(CustomerModel c)
        {
            DAL.Models.CustomerModel.CreateCustomerProfile(c);


        }

        // PUT: api/Customer/5
        [Route("api/UpdateCustomer")]
        public void UpdateCustomer(CustomerModel c)
        {
            DAL.Models.CustomerModel.UpdateCustomerProfile(c);


        }

        // DELETE: api/Customer/5
        [Route("api/DeleteCustomer")]
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            DAL.Models.CustomerModel.DeleteCustomerProfile(id);
        }


        [Route("api/login")]
            public IHttpActionResult loginDetails([FromBody]LoginModel Lm)
            {
                return Json(LoginModel.GetLogIns(Lm));
            }

        [Route("api/Customerlogin")]
        public IHttpActionResult CustomerLoginDetails([FromBody]CustomerLoginModel Clm)
        {
            return Json(CustomerLoginModel.GetCusLogIns(Clm));
        }

        [Route("api/GetAllTransaction")]
        public List<Transaction_Bank> GetAllTransaction(int accountNumber)
        {
            return DAL.Models.TransactionModel.GetAllTransaction(accountNumber);
        }


        [Route("api/CreateTransaction")]
        public void CreateTransactionProfile(TransactionModel trans)
        {
            DAL.Models.TransactionModel.CreateTransactionProfile(trans);


        }


        [HttpGet]
        [Route("api/GetToken")]
        public Object GetToken()
        {
            string key = "my_secret_key_12345";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "Shubham Raj"));



            var token = new JwtSecurityToken(issuer,
            issuer,
            permClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
        }


        [HttpPost]
        [Route("api/GetName1")]
        public String GetName1()
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
        [Route("api/GetName2")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                return new
                {
                    data = name
                };



            }



            return null;
        }

    }



}

