using AcademyA_CDO.Week6.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}
