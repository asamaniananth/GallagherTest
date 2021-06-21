using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Data.ViewModels;

namespace MVCTest.Data.DAL
{
    public interface IRepository
    {
        List<EmployeeViewModel> GetAllAsViewModels(string optionalPathOrContext);
    }
}
