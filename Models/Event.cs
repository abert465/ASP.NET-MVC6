using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EventPlanner3.Models

{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int EventTypeID { get; set; }
        public decimal Price { get; set; }
        public virtual EventType EventType { get; set; }

    }
    public class EventType
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Event> Event { get; set;}
    }
}
