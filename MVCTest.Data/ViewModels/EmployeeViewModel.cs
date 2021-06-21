using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTest.Data.Entities;

namespace MVCTest.Data.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int YearsEmployed { get; set; }
        public bool PhoneVisible => !string.IsNullOrWhiteSpace(Phone);
        public bool EmailVisible => !string.IsNullOrWhiteSpace(Email);

        public EmployeeViewModel(Employee employee)
        {
            Id = employee.Id;
            Email = employee.Email;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Phone = employee.Phone;
            YearsEmployed = employee.YearsEmployed;            
        }

        public EmployeeViewModel()
        {

        }
    }
}
