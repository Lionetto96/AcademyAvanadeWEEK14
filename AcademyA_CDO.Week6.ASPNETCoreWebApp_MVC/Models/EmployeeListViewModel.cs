using System.ComponentModel;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Models
{
    public class EmployeeListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Employee Code")]
        public string EmployeeCode { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
