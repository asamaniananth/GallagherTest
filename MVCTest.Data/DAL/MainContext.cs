using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Data.Entities;

namespace MVCTest.Data.DAL
{
    public class MainContext : DbContext
    {
        public MainContext() : base("MainContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
