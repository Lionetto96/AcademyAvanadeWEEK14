using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string  Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        User,
        Administrator
    }
}
