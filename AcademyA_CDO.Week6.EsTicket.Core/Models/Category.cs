using System.Collections.Generic;

namespace AcademyA_CDO.Week6.EsTicket.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
