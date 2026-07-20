using EmployeeManagementConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementConsoleApp.UI
{
    internal class ConsoleMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\n====== Employee Management System ======");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Update Employee");
            Console.WriteLine("3. Deactivate Employee");
            Console.WriteLine("4. Search Employee (Name/ID)");
            Console.WriteLine("5. Filter by Department");
            Console.WriteLine("6. Sort Employees");
            Console.WriteLine("7. Show Salary Reports");
            Console.WriteLine("8. View All Employees");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");
        }




      
    }
}
