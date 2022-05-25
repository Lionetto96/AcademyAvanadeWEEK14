using AcademyA_CDO.Week6.EsTicket.Core.Interfaces;
using AcademyA_CDO.Week6.EsTicket.Core.Models;
using System;
using System.Collections.Generic;

namespace AcademyA_CDO.Week6.EsTicket.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly ITicketRepository ticketRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly IUserRepository userRepo;

        public MainBusinessLayer(
            ITicketRepository ticketRepo,
            ICategoryRepository categoryRepo,
            IUserRepository userRepo)
        {
            this.ticketRepo = ticketRepo;
            this.categoryRepo = categoryRepo;
            this.userRepo = userRepo;
        }

        #region Tickets

        public bool AddNewTicket(Ticket newTicket)
        {
            if (newTicket == null)
                return false;

            newTicket.Created = DateTime.Now;
            newTicket.State = State.New;

            return ticketRepo.AddItem(newTicket);
        }

        public bool AddNoteToTicket(int ticketId, Note newNote)
        {
            if (newNote == null || ticketId <= 0)
                return false;

            var ticket = ticketRepo.GetById(ticketId);
            ticket.Notes.Add(newNote);

            return ticketRepo.UpdateItem(ticket);
        }

        public bool AssignTicket(int ticketId, string owner)
        {
            if (string.IsNullOrEmpty(owner) || ticketId <= 0)
                return false;

            var ticket = ticketRepo.GetById(ticketId);
            ticket.Owner = owner;

            return ticketRepo.UpdateItem(ticket);
        }

        public bool CloseTicket(int ticketId)
        {
            if (ticketId <= 0)
                return false;

            var ticket = ticketRepo.GetById(ticketId);
            ticket.State = State.Closed;
            ticket.Closed = DateTime.Now;

            return ticketRepo.UpdateItem(ticket);
        }

        public bool DeleteTicketById(int ticketId)
        {
            if (ticketId <= 0)
                return false;

            return ticketRepo.DeleteById(ticketId);
        }

        public IEnumerable<Ticket> FetchTickets(Func<Ticket, bool> filter = null)
        {
            return ticketRepo.Fetch(filter);
        }

        public Ticket GetTicketById(int ticketId)
        {
            if (ticketId <= 0)
                return null;

            return ticketRepo.GetById(ticketId);
        }

        public bool UpdateTicket(Ticket updatedTicket)
        {
            if (updatedTicket == null)
                return false;

            return ticketRepo.UpdateItem(updatedTicket);
        }

        #endregion

        #region Categories

        public IEnumerable<Category> FetchCategories(Func<Category, bool> filter = null)
        {
            return categoryRepo.Fetch(filter);
        }

        public Category GetCategoryById(int categoryId)
        {
            if (categoryId <= 0)
                return null;

            return categoryRepo.GetById(categoryId);
        }

        public bool AddNewCategory(Category newCategory)
        {
            if (newCategory == null)
                return false;

            return categoryRepo.AddItem(newCategory);
        }

        public bool UpdateCategory(Category updatedCategory)
        {
            if (updatedCategory == null)
                return false;

            return categoryRepo.UpdateItem(updatedCategory);
        }

        public bool DeleteCategoryById(int categoryId)
        {
            if (categoryId <= 0)
                return false;

            return categoryRepo.DeleteById(categoryId);
        }

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return userRepo.GetUserByUsername(username);
        }

        #endregion
    }
}
