using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.Data.ViewModels
{
    public class HomePageViewModel
    {
        public List<EmployeeViewModel> FromCSV { get; set; }
        public List<EmployeeViewModel> FromDB { get; set; }

        public HomePageViewModel()
        {
            FromCSV = new List<EmployeeViewModel>();
            FromDB = new List<EmployeeViewModel>();
        }
    }
}
