using System.ComponentModel.DataAnnotations;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string Username { get; set;}
        [Required]
        public string Password { get; set;}
        public string ReturnUrl { get; set;}
    }
}
