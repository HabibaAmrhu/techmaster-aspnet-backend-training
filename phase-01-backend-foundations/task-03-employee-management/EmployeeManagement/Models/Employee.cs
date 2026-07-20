using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementConsoleApp.Models
{
    enum Department
    {
        IT,
        HR,
        Sales,
        Finance,
        Marketing,
        Support
    }
    internal class Employee
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public string Position {  get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? PhoneNumber { get; set; }
        public string? ManagerName { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
