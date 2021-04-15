using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Event
    {
        public Event (){
            this.Start = new EventDateTime()
            {
                TimeZone = "America/Los_Angeles"
            };
            this.End = new EventDateTime()
            {
                TimeZone = "America/Los_Angeles"
            };

        }
       public List<Attendee> Attendees { get; set; }

        public string Id { get; set; }

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

public class Attendee
{
    public string Email { get; set; }
}