using System;

namespace AcademyA_CDO.Week6.EsTicket.Core.Models
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string NoteText { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
