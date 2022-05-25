using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AcademyA_CDO.Week6.Ticket.Core.Models;

namespace AcademyA_CDO.Week6.Ticket.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
    public enum Role
    {
        User,
        Administrator
    }
}
