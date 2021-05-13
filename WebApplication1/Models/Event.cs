using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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




        [Required(ErrorMessage = "A Summary of the Event is required")] public string Summary { get; set; }


        [Required(ErrorMessage = "A Description is required")] public string Description { get; set; }

        [Required(ErrorMessage = "A Start Time is required")] public EventDateTime Start { get; set; }

        [Required(ErrorMessage = "An End Time is required")] public EventDateTime End { get; set; }
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