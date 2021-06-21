using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Data.BusinessLogic;
using MVCTest.Data.Entities;
using MVCTest.Data.ViewModels;

namespace MVCTest.Data.DAL
{
    public class CsvRepository : IRepository
    {
        AssessmentCodeBehindBusinessLogic ctxAdmin = new AssessmentCodeBehindBusinessLogic();
        public List<EmployeeViewModel> GetAllAsViewModels(string optionalPathOrContext)
        {
            List<EmployeeViewModel> employeeViewModels = ctxAdmin.employeeList;            
            return employeeViewModels;
        }        
    }
}
