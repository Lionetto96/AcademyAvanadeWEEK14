using AcademyA_CDO.Week6.Core.Interfaces;
using AcademyA_CDO.Week6.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public MainBusinessLayer(IEmployeeRepository employeeRepo, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepo;
            _userRepository = userRepository;
        }

        public IEnumerable<Employee> FetchEmployees(Func<Employee, bool> filter = null)
        {
            return _employeeRepository.Fetch(filter);
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
                return null;

            return _employeeRepository.GetById(id);
        }

        public BLResult AddNewEmployee(Employee newEmployee)
        {
            if (newEmployee is null)
                return new BLResult(false, "Invalid employee data");

            var result = _employeeRepository.AddItem(newEmployee);

            return new BLResult(result, result ? "" : "Cannot save employee");
        }

        public BLResult UpdateEmployee(Employee updatedEmployee)
        {
            if(updatedEmployee is null)
                return new BLResult(false, "Invalid employee data");

             var result = _employeeRepository.UpdateItem(updatedEmployee);

            return new BLResult(result, result ? "" : "Cannot update employee");

        }

        public BLResult DeleteEmployeeById(int id)
        {
            if(id <= 0)
                return new BLResult(false, "Invalid employee id");

            var result = _employeeRepository.DeleteItemById(id);
            return new BLResult(result, result ? "" : "Cannot delete employee");
        }

        public User GetAccount(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return _userRepository.GetByUsername(username);
        }
    }
}
