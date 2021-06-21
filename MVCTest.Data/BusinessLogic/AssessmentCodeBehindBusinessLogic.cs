using MVCTest.Data.Utils;
using MVCTest.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace MVCTest.Data.BusinessLogic
{
    public class AssessmentCodeBehindBusinessLogic
    {
        private readonly string employeeCsvPath = ConfigurationManager.AppSettings[Constants.APP_SETTINGS_EMPLOYEES_CSV_PATH].ToString();
        public string CurrentPath { get; private set; }
        public int CurrentNoOfEmployees { get; private set; }

        public List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();

        public AssessmentCodeBehindBusinessLogic()
        {
            string hostingPath = HostingEnvironment.ApplicationPhysicalPath;
            CurrentPath= Path.GetFullPath(Path.Combine(hostingPath, employeeCsvPath));
            employeeList = GetEmployeeList();
            CurrentNoOfEmployees = employeeList.Count;
        }        

        public List<EmployeeViewModel> GetEmployeeList()
        {            
            using (var reader = new StreamReader(CurrentPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    employeeList.Add(new EmployeeViewModel()
                    {
                        Id = long.Parse(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        Email = values[3],
                        Phone = values[4],
                        YearsEmployed = string.IsNullOrEmpty(values[5]) ? 0 : int.Parse(values[5])
                    });
                }
            }
            return employeeList;
        }

        public EmployeeViewModel GetEmployeeById(long id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();            
            employeeViewModel = (from x in employeeList
                                 where x.Id == id
                                 select x).FirstOrDefault();

            return employeeViewModel;
        }

        public void DeleteItemById(long id)
        {            
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < employeeList.Count)
            {
                if (!employeeList[i].Id.Equals(id))
                {
                    sb.Append(employeeList[i].Id + ",");
                    sb.Append(employeeList[i].FirstName + ",");
                    sb.Append(employeeList[i].LastName + ",");
                    sb.Append(employeeList[i].Email + ",");
                    sb.Append(employeeList[i].Phone + ",");
                    sb.Append(employeeList[i].YearsEmployed.ToString());
                    sb.Append(Environment.NewLine);
                }
                i++;
            }            
            File.WriteAllText(CurrentPath, sb.ToString());            
        }

        public void AddItem(EmployeeViewModel employee)
        {
            long idValue =employeeList[employeeList.Count - 1].Id + 1;            
            StringBuilder sb = new StringBuilder();
            sb.Append(idValue + ",");
            sb.Append(employee.FirstName + ",");
            sb.Append(employee.LastName + ",");
            sb.Append(employee.Email + ",");
            sb.Append(employee.Phone + ",");
            sb.Append(employee.YearsEmployed.ToString());
            sb.Append(Environment.NewLine);
            File.AppendAllText(CurrentPath, sb.ToString());
        }

        public void EditItemById(long id)
        {
            GetEmployeeById(id);
        }

        public void UpdateItem(EmployeeViewModel employee)
        {
            DeleteItemById(employee.Id);
            AddItem(employee);
        }
    }
}
