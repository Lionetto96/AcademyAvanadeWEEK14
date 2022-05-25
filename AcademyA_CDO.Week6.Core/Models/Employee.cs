using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Level { get; set; }
    }
}
