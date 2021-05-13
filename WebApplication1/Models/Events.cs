using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Events
    {
        public Events (){
            this.Start = new EventDateTime()
            {
                TimeZone = "Asia/Kolkata"
            };
            this.End = new EventDateTime()
            {
                TimeZone = "Asia/Kolkata"
            };

        }

        public string Summary { get; set; }

        public string Description { get; set; }

        public EventDateTime Start { get; set; }

        public EventDateTime End { get; set; }
    }
}

public class EventDateTime
{
    public string DateTime { get; set; }

    public string TimeZone { get; set; }
}