using AcademyA_CDO.Week6.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Employee GetEmployeeByCode(string employeeCode);
    }
}
