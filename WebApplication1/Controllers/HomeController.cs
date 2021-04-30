using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var credentialsFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\credentials.json";
            var credentials = JObject.Parse(System.IO.File.ReadAllText(credentialsFile));
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));

            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("client_id", credentials["client_id"].ToString());
            request.AddQueryParameter("client_secret", credentials["client_secret"].ToString());
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", tokens["refresh_token"].ToString());

            restClient.BaseUrl = new System.Uri("https://oauth2.googleapis.com/token");
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject newTokens = JObject.Parse(response.Content);
                newTokens["refresh_token"] = tokens["refresh_token"].ToString();
                System.IO.File.WriteAllText(tokenFile, newTokens.ToString());
            }
            ViewData["warn"] = false;
            return View();
        }
        public ActionResult ParameterError()
        {
            ViewData["warn"] = true;
            return View("Index");
        }
        public ActionResult OauthRedirect()
        {

            var credentialsFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\credentials.json";

            JObject credentials = JObject.Parse(System.IO.File.ReadAllText(credentialsFile));
            var client_id = credentials["client_id"];

            var redirectUrl = "https://accounts.google.com/o/oauth2/v2/auth?" +
                                     "scope=https://www.googleapis.com/auth/calendar+https://www.googleapis.com/auth/calendar.events&" +
                                     "access_type=offline&" +
                                     "include_granted_scopes=true&" +
                                     "response_type=code&" +
                                     "state=hellothere&" +
                                     "redirect_uri=https://localhost:44384/oauth/callback&" +
                                     "client_id="+ client_id;
            return Redirect(redirectUrl);

        }
    }
}