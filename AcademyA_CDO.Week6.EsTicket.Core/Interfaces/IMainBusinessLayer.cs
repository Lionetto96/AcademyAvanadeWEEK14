using AcademyA_CDO.Week6.EsTicket.Core.Models;
using System;
using System.Collections.Generic;

namespace AcademyA_CDO.Week6.EsTicket.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region Tickets

        IEnumerable<Ticket> FetchTickets(Func<Ticket, bool> filter = null);
        Ticket GetTicketById(int ticketId);
        bool AddNewTicket(Ticket newTicket);
        bool UpdateTicket(Ticket updatedTicket);
        bool DeleteTicketById(int ticketId);
        bool AssignTicket(int ticketId, string owner);
        bool CloseTicket(int ticketId);
        bool AddNoteToTicket(int ticketId, Note newNote);

        #endregion

        #region Categories

        IEnumerable<Category> FetchCategories(Func<Category, bool> filter = null);
        Category GetCategoryById(int categoryId);
        bool AddNewCategory(Category newCategory);
        bool UpdateCategory(Category updatedCategory);
        bool DeleteCategoryById(int categoryId);

        #endregion

        #region Users

        User GetUserByUsername(string username);

        #endregion
    }
}
