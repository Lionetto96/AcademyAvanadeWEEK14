using AcademyA_CDO.Week6.EsTicket.Core.Models;
using System;
using System.Linq;

namespace AcademyA_CDO.Week6.EsTicket.Core.EF.Mock
{
    public class DbInitializer
    {
        public static void Initialize(TicketContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Tickets.Any())
            {
                var tickets = new Ticket[]
                    {
                    new Ticket
                    {
                        Title = "Qualcosa non funziona",
                        Description = "Quando accendo il pc non si accende, e non riesco a lavorare",
                        Requestor = "diego.angelino",
                        Owner = "mario.rossi",
                        Created = new DateTime(2022, 01, 01, 00, 00, 00),
                        State = State.New,
                        Priority = Priority.Normal
                    },
                    new Ticket
                    {
                        Title = "Pulsante 'conferma' non funzionante",
                        Description = "Non e' possibile visualizzare il punsante di conferma all'edit di un ticket",
                        Requestor = "diego.angelino",
                        Owner = "mario.derossi",
                        Created = new DateTime(2022, 01, 02, 01, 00, 00),
                        State = State.New,
                        Priority = Priority.High
                    }
                    };

                foreach (Ticket e in tickets)
                {
                    context.Tickets.Add(e);
                }

                context.SaveChanges();
            }


            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User{ Username = "diego.angelino", Password = "pippo123", Role = Role.Administrator},
                    new User{ Username = "renata.carriero", Password = "pippo123", Role = Role.User}
                };

                foreach (User u in users)
                {
                    context.Users.Add(u);
                }

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category{ CategoryName = "Unknown"},
                    new Category{ CategoryName = "System"},
                    new Category{ CategoryName = "Development"},
                    new Category{ CategoryName = "Office"},
                    new Category{ CategoryName = "SAP"}
                };

                foreach (Category c in categories)
                {
                    context.Categories.Add(c);
                }

                context.SaveChanges();
            }
        }
    }
}
