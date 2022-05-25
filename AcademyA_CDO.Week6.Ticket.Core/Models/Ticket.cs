using System;
using System.Collections.Generic;
using System.Text;
using AcademyA_CDO.Week6.Ticket.Core.Models;

namespace AcademyA_CDO.Week6.Ticket.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Requestor { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public virtual Category Category { get; set; }
        public State State { get; set; }
        public string Owner { get; set; }
        public DateTime? Closed { get; set; }

        public virtual List<Note> Notes { get; set; }
    }

    public enum Priority
    {
        Low,
        Normal,
        High
    }

    public enum State
    {
        New,
        Assigned,
        OnGoing,
        Closed
    }

    //public enum Category
    //{
    //    Unknown,
    //    System,
    //    Development,
    //    Office,
    //    SAP
    //}
}

