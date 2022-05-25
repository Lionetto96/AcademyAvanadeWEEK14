using System;
using System.Collections.Generic;
using System.Text;
using AcademyA_CDO.Week6.Ticket.Core.Models;

namespace AcademyA_CDO.Week6.Ticket.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}
