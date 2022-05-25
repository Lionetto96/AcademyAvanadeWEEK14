using AcademyA_CDO.Week6.Core.Interfaces;
using AcademyA_CDO.Week6.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyA_CDO.Week6.Core.EF.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext ctx;

        public EFEmployeeRepository(EmployeeContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddItem(Employee newItem)
        {
            if (newItem == null)
                return false;

            this.ctx.Employees.Add(newItem);
            this.ctx.SaveChanges();

            return true;
        }

        public bool DeleteItemById(int id)
        {
            if (id <= 0)
                return false;

            var itemToBeDeleted = this.ctx.Employees.Find(id);

            if (itemToBeDeleted == null)
                return false;

            this.ctx.Employees.Remove(itemToBeDeleted);
            this.ctx.SaveChanges();

            return true;
        }

        public IEnumerable<Employee> Fetch(Func<Employee, bool> filter = null)
        {
            if (filter != null)
                return this.ctx.Employees.Where(filter);

            return this.ctx.Employees;
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            if (id <= 0)
                return null;

            return this.ctx.Employees.Find(id);
        }

        public bool UpdateItem(Employee updatedItem)
        {
            if (updatedItem == null)
                return false;

            this.ctx.Entry(updatedItem).State = EntityState.Modified;
            this.ctx.SaveChanges();

            return true;
        }
    }
}
