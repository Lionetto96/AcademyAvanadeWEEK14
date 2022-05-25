using AcademyA_CDO.Week6.EsTicket.Core.Interfaces;
using AcademyA_CDO.Week6.EsTicket.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly TicketContext ctx;

        public EFCategoryRepository(TicketContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddItem(Category newItem)
        {
            try
            {
                ctx.Categories.Add(newItem);
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

            var categoryToBeDeleted = ctx.Categories.Find(id);

            ctx.Categories.Remove(categoryToBeDeleted);
            ctx.SaveChanges();

            return true;
        }

        public IEnumerable<Category> Fetch(Func<Category, bool> filter = null)
        {
            if (filter != null)
                return ctx.Categories
                    .Where(filter);

            return ctx.Categories;
        }

        public Category GetById(int id)
        {
            if (id <= 0)
                return null;

            var category = ctx.Categories
                .FirstOrDefault(t => t.Id == id);

            return category;
        }

        public bool UpdateItem(Category updatedItem)
        {
            try
            {
                ctx.Entry(updatedItem).State = EntityState.Modified;
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
