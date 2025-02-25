﻿
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CalendarEventController : Controller {
        bool liveEvent = true;
        public ActionResult BookEvent()
        {
            liveEvent = true;
            ViewData["warning"] = false;
            ViewData["booked"] = false;
            return View();
        }
        public ActionResult BookConsultation()
        {
            liveEvent = false;
            ViewData["warning"] = false;
            ViewData["booked"] = false;
            return View();
        }
        public ActionResult BookError()
        {
            ViewData["warning"] = true;
            ViewData["booked"] = false;
            return View("BookEvent");
        }
        public ActionResult ConsultError()
        {
            ViewData["warning"] = true;
            ViewData["booked"] = false;
            return View("BookConsultation");
        }
        public ActionResult Booked()
        {
            ViewData["warning"] = false;
            ViewData["booked"] = true;
            return View("BookEvent");
        }
        public ActionResult BookedConsult()
        {
            ViewData["warning"] = false;
            ViewData["booked"] = true;
            return View("BookConsultation");
        }

        public ActionResult DeleteEvent(string identifier)
        {
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));

            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("key", "AIzaSyBPhlWq_ZZqOj1crvD7cOXOCU9VY6cgnWI");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events/" + identifier);
            var response = restClient.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return RedirectToAction("AllEvents", "CalendarEvent", new { status = "deleted" });
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult UpdateEvent(string identifier)
    {
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));

            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("key", "AIzaSyBPhlWq_ZZqOj1crvD7cOXOCU9VY6cgnWI");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events/" + identifier);
            var response = restClient.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject calendarEvent = JObject.Parse(response.Content);
                return View(calendarEvent.ToObject<Event>());
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult UpdateEvent(string identifier, Event calendarEvent)
        {
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();
           
            calendarEvent.Start.DateTime = DateTime.Parse(calendarEvent.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
            calendarEvent.End.DateTime = DateTime.Parse(calendarEvent.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");

            var model = JsonConvert.SerializeObject(calendarEvent, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddQueryParameter("key", "AIzaSyBPhlWq_ZZqOj1crvD7cOXOCU9VY6cgnWI");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events/" + identifier);
            var response = restClient.Patch(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("AllEvents", "CalendarEvent", new {status = "updated"});
            }
            return View("Error");
        }


        public ActionResult Event(string identifier)
        {
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("key", "AIzaSyBPhlWq_ZZqOj1crvD7cOXOCU9VY6cgnWI");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events/"+identifier);
            var response = restClient.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject calendarEvent = JObject.Parse(response.Content);
                return View(calendarEvent.ToObject<Event>());
            }
            return View("Error");
        }


        public ActionResult AllEvents()
        {
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("key", "AIzaSyBPhlWq_ZZqOj1crvD7cOXOCU9VY6cgnWI");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");


            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events");
            var response = restClient.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject calendarEvents = JObject.Parse(response.Content);
                var allEvents = calendarEvents["items"].ToObject<IEnumerable<Event>>();
                return View(allEvents);
            }
            return View("Error");

        }
      [HttpPost]
      public ActionResult CreateEvent(Event calendarEvent)
        {
           
            var tokenFile = "C:\\Users\\vanil\\source\\repos\\WebApplication1\\WebApplication1\\Files\\token.json";
            var tokens = JObject.Parse(System.IO.File.ReadAllText(tokenFile));

            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();
            DateTime dt;
            var isValid = DateTime.TryParse(calendarEvent.Start.DateTime, out dt);
            
            if (isValid)
            {
                calendarEvent.Start.DateTime = DateTime.Parse(calendarEvent.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
                calendarEvent.End.DateTime = DateTime.Parse(calendarEvent.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
                var model = JsonConvert.SerializeObject(calendarEvent, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()

                });
                request.AddQueryParameter("key", "AIzaSyBPhlWq_ZZqOj1crvD7cOXOCU9VY6cgnWI");
                request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", model, ParameterType.RequestBody);

                restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events");
                var response = restClient.Post(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (liveEvent)
                        return RedirectToAction("Booked", "CalendarEvent", new { status = "Booked" });
                    else
                        return RedirectToAction("BookedConsult", "CalendarEvent", new { status = "Booked" });

                }
                return View("Error");
            }
            else
            {
                return RedirectToAction("BookError", "CalendarEvent", new { status = "IncorrectEventParameters" });
            }
        }
    }
}