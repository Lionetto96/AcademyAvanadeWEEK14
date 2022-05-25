using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Ticket.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
