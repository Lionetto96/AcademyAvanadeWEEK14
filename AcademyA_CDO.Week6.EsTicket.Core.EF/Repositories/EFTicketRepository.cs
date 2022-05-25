using AcademyA_CDO.Week6.EsTicket.Core.Interfaces;
using AcademyA_CDO.Week6.EsTicket.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Repositories
{
    public class EFTicketRepository : ITicketRepository
    {
        private readonly TicketContext ctx;

        public EFTicketRepository(TicketContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Ticket> Fetch(Func<Ticket, bool> filter = null)
        {
            if (filter != null)
                return ctx.Tickets
                    .Include(t => t.Notes)
                    .Include(t => t.Category)
                    .Where(filter);

            return ctx.Tickets
                .Include(t => t.Notes)
                .Include(t => t.Category);
        }

        public Ticket GetById(int id)
        {
            if (id <= 0)
                return null;

            var ticket = ctx.Tickets
                 .Include(t => t.Notes)
                .Include(t => t.Category)
                .FirstOrDefault(t => t.Id == id);

            return ticket;
        }

        public bool AddItem(Ticket newItem)
        {
            try
            {
                var cat = ctx.Categories.FirstOrDefault(c => c.Id == newItem.Category.Id);
                newItem.Category = cat;

                ctx.Tickets.Add(newItem);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateItem(Ticket updatedItem)
        {
            try
            {
                //ctx.Entry(updatedItem).State = EntityState.Modified;

                var cat = ctx.Categories.FirstOrDefault(c => c.Id == updatedItem.Category.Id);
                updatedItem.Category = cat;

                this.ctx.Entry(updatedItem).State = EntityState.Modified;
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;

            try
            {
                var ticketToBeDeleted = ctx.Tickets.Find(id);

                ctx.Tickets.Remove(ticketToBeDeleted);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
