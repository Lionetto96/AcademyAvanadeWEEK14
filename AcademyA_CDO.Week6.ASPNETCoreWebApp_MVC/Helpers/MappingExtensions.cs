using AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Models;
using AcademyA_CDO.Week6.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Helpers
{
    public static class MappingExtensions
    {
        public static EmployeeListViewModel ToListViewModel(this Employee employee)
        {
            return new EmployeeListViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
        }

        public static IEnumerable<EmployeeListViewModel> ToListViewModel(this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.ToListViewModel());
        }

        public static EmployeeDetailsViewModel ToDetailsViewModel(this Employee employee)
        {
            return new EmployeeDetailsViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Birthdate = employee.Birthdate.ToString("dd-MMM-yyyy"),
                Level = employee.Level
            };
        }

        public static IEnumerable<EmployeeDetailsViewModel> ToDetailsViewModel(this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.ToDetailsViewModel());
        }

        public static Employee ToEmployee(this EmployeeEditViewModel viewModel)
        {
            return new Employee
            {
                Id = viewModel.Id,
                EmployeeCode = viewModel.EmployeeCode,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Birthdate = viewModel.Birthdate,
                Level = viewModel.Level
            };
        }

        public static EmployeeEditViewModel ToEditViewModel(this Employee employee)
        {
            return new EmployeeEditViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName.ToUpper(),
                Birthdate = employee.Birthdate,
                Level = employee.Level
            };
        }

        public static IEnumerable<EmployeeEditViewModel> ToEditViewModel(this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.ToEditViewModel());
        }
    }
}
