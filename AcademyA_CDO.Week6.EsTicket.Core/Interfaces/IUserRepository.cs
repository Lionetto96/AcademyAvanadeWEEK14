using AcademyA_CDO.Week6.EsTicket.Core.Models;

namespace AcademyA_CDO.Week6.EsTicket.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}
