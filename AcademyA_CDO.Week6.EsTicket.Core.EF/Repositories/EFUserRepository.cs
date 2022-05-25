using AcademyA_CDO.Week6.EsTicket.Core.Interfaces;
using AcademyA_CDO.Week6.EsTicket.Core.Models;
using System.Linq;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly TicketContext ctx;

        public EFUserRepository(TicketContext ctx)
        {
            this.ctx = ctx;
        }

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return new User();

            var user = ctx.Users
                .FirstOrDefault(u => u.Username == username);

            return user;
        }
    }
}
