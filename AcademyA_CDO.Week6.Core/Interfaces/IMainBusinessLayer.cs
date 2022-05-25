using AcademyA_CDO.Week6.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        IEnumerable<Employee> FetchEmployees(Func<Employee, bool> filter = null);
        Employee GetEmployeeById(int id);
        BLResult AddNewEmployee(Employee newEmployee);
        BLResult UpdateEmployee(Employee updatedEmployee);
        BLResult DeleteEmployeeById(int id);

        User GetAccount(string username);
    }
}
