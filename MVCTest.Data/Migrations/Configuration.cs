using System.Collections.Generic;
using MVCTest.Data.Entities;

namespace MVCTest.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCTest.Data.DAL.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCTest.Data.DAL.MainContext context)
        {
            var employees = new List<Employee>
            {
                new Employee(){Id = 1, Email = "ozzy@blacksabbath.com", FirstName = "Ozzy", LastName = "Osbourne", IsDeleted = false, Phone = "6195551234", YearsEmployed = 10},
                new Employee(){Id = 2, Email = "kurt@nirvana.com", FirstName = "Kurt", LastName = "Cobain", IsDeleted = false, Phone = "7608896687", YearsEmployed = 5},
                new Employee(){Id = 3, Email = "bono@u2.com", FirstName = "Paul", LastName = "Hewson", IsDeleted = true, Phone = "8884691212", YearsEmployed = 75},
                new Employee(){Id = 4, Email = "jimmy.page@zeppelin.com", FirstName = "Jimmy", LastName = "Page", IsDeleted = false, Phone = "5208784568", YearsEmployed = 23},
                new Employee(){Id = 5, Email = "", FirstName = "Jon", LastName = "Bongiovi", IsDeleted = false, Phone = "1234567890", YearsEmployed = 17},
                new Employee(){Id = 6, Email = "rod@rodstewart.com", FirstName = "Roderick", LastName = "Stewart", IsDeleted = true, Phone = "5650129865", YearsEmployed = 62},
            };

            context.Employees.AddOrUpdate(e => e.Id, employees.ToArray());
            context.SaveChanges();
        }
    }
}
