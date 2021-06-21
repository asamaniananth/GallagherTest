using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Data.Entities;
using MVCTest.Data.ViewModels;

namespace MVCTest.Data.DAL
{
    public class SqlRepository : IRepository
    {
        public List<EmployeeViewModel> GetAllAsViewModels(string optionalPathOrContext)
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            using (var context = new MainContext())
            {
                foreach (Employee employee in context.Employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel(employee));
                }
            }
            //MainContext context = new MainContext();
            return employeeViewModels;
        }
    }
}
