using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Employee Code")]
        public string EmployeeCode { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        public string Level { get; set; }

        public List<SelectListItem> AvailableLevels { get; set; }
    }
}
