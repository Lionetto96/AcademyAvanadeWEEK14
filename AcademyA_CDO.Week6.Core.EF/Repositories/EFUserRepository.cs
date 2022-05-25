using AcademyA_CDO.Week6.Core.Interfaces;
using AcademyA_CDO.Week6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyA_CDO.Week6.Core.EF.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EmployeeContext ctx;

        public EFUserRepository(EmployeeContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddItem(User newItem)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return ctx.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public bool UpdateItem(User updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
