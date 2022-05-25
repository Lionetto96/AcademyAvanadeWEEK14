using AcademyA_CDO.Week6.Core.Models;
using System;
using System.Linq;

namespace AcademyA_CDO.Week6.Core.EF.Mock
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
                return;
            var employees = new Employee[]
            {
                    new Employee{FirstName="Carson",LastName="Alexander",Birthdate=DateTime.Parse("1965-01-01"), EmployeeCode="EMP001"},
                    new Employee{FirstName="Meredith",LastName="Alonso",Birthdate=DateTime.Parse("1972-02-01"), EmployeeCode="EMP002"},
                    new Employee{FirstName="Arturo",LastName="Anand",Birthdate=DateTime.Parse("1963-03-01"), EmployeeCode="EMP003"},
                    new Employee{FirstName="Gytis",LastName="Barzdukas",Birthdate=DateTime.Parse("1982-04-01"), EmployeeCode="EMP004"},
                    new Employee{FirstName="Yan",LastName="Li",Birthdate=DateTime.Parse("1992-05-01"), EmployeeCode="EMP005"},
                    new Employee{FirstName="Peggy",LastName="Justice",Birthdate=DateTime.Parse("1961-06-01"), EmployeeCode="EMP006"},
                    new Employee{FirstName="Laura",LastName="Norman",Birthdate=DateTime.Parse("1953-07-01"), EmployeeCode="EMP007"},
                    new Employee{FirstName="Nino",LastName="Olivetto",Birthdate=DateTime.Parse("1955-09-01"), EmployeeCode="EMP008"}
            };

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }

            context.SaveChanges();


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
    }
}
