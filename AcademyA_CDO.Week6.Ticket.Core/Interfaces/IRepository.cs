using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Ticket.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T, bool> filter = null);
        T GetById(int id);
        bool AddItem(T newItem);
        bool UpdateItem(T updatedItem);
        bool DeleteById(int id);
    }
}
