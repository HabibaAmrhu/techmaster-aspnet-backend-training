using EmployeeManagementConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementConsoleApp.Services
{
    internal class EmployeeReportService
    {
        public void ShowSalaryReports(List<Employee> employees)
        {
            if (employees == null || !employees.Any()) return;

            var activeEmps = employees.Where(e => e.IsActive).ToList();

            Console.WriteLine("\n--- Company Financial Reports ---");
            Console.WriteLine($"Total Payroll  : {activeEmps.Sum(e => e.Salary):C}");
            Console.WriteLine($"Average Salary : {activeEmps.Average(e => e.Salary):C}");

            var highest = activeEmps.OrderByDescending(e => e.Salary).FirstOrDefault();
            var lowest = activeEmps.OrderBy(e => e.Salary).FirstOrDefault();

            Console.WriteLine($"Highest Salary : {highest?.Salary:C} ({highest?.Name})");
            Console.WriteLine($"Lowest Salary  : {lowest?.Salary:C} ({lowest?.Name})");

            Console.WriteLine("\n--- Employee Status Summary ---");
            Console.WriteLine($"Active Employees  : {employees.Count(e => e.IsActive)}");
            Console.WriteLine($"Inactive Employees: {employees.Count(e => e.IsActive == false) }");

            Console.WriteLine("\n--- Department Distribution ---");
            var deptCounts = employees.GroupBy(e => e.Department)
                                      .Select(g => new { Dept = g.Key, Count = g.Count() });

            foreach (var item in deptCounts)
            {
                Console.WriteLine($"{item.Dept}: {item.Count} employees");
            }
        }
    }
}
