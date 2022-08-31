using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult UploadTest()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UploadTest(HttpPostedFileBase file)
        {
            HttpResponseMessage resultResponse = null;

            Models.manager_info manager_Info = new Models.manager_info();
            manager_Info.manager_account = "banana1";

            string confirm_info = Newtonsoft.Json.JsonConvert.SerializeObject(manager_Info);
            HttpContent confirm_content = new StringContent(confirm_info);
            HttpClient confirm_client = new HttpClient();
            String confirm_urlString = "http://127.0.0.1:8000/api/company/checkManagerInfo";
            confirm_client.BaseAddress = new Uri(confirm_urlString);
            confirm_content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //resultResponse = confirm_client.PostAsJsonAsync(confirm_urlString, confirm_content).GetAwaiter().GetResult();
            resultResponse = confirm_client.PostAsync("", confirm_content).GetAwaiter().GetResult();
            String result_pre = resultResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            //CookieContainer cookies = new CookieContainer();
            //Uri uri = new Uri("http://127.0.0.1:8000/api/company/");
            //IEnumerable <Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
            //foreach (Cookie cookie in responseCookies)
            //    Console.WriteLine(cookie.Name + ": " + cookie.Value);

            var account = Request.Cookies["account"].Value;
            var token = Request.Cookies["authorized"].Value;


            Models.UserInfo result = new Models.UserInfo();
            result.candidate_account = "apple2";
            result.candidate_name = "appleName2";

            // var target_gile = new System.IO.StreamReader(file, System.Text.Encoding.UTF8);

            var target_file = System.IO.File.ReadAllText(@"C:\Users\pkpk1\Documents\c_test.zip");

            result.submit_file = target_file;
            result.mark = 100;

            string tableString = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            HttpContent content = new StringContent(tableString);
            
            //HttpClient client = new HttpClient();   

            String urlString = "http://127.0.0.1:8000/api/company/edit/updatePersonInfo";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlString);

            var cookieContainer = new CookieContainer();

            cookieContainer.Add(client.BaseAddress, new Cookie("account", account));
            cookieContainer.Add(client.BaseAddress, new Cookie("authorized", token));




            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            
            resultResponse = client.PostAsync("", content).GetAwaiter().GetResult();

            String result_1 = resultResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();





            return View();
        }


    }
}
