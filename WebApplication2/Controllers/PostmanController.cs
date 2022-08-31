using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
   
    public class PostmanController : ApiController
    {
        // GET: Postman
        public int Index()
        {

            HttpRequestMessage request = this.Request;
            HttpContent content = request.Content;
            String jsonString = content.ReadAsStringAsync().GetAwaiter().GetResult();
            return 1;
        }

        [System.Web.Http.HttpPost]
        public String Postman1(string clientId, string clientSecret)
        {


            return "TEST";
        }

    }
}