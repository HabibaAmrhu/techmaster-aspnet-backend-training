using EmployeeManagementConsoleApp.Models;
using EmployeeManagementConsoleApp.Services;
using EmployeeManagementConsoleApp.UI;

namespace EmployeeManagementConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeService empService = new EmployeeService();
            EmployeeReportService reportService = new EmployeeReportService();
            ConsoleMenu menu = new ConsoleMenu();

            bool isRunning = true;

            while (isRunning)
            {
                menu.DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter ID (e.g., EMP-013): ");
                        string id = Console.ReadLine();
                        Console.Write("Full Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Salary: ");
                        decimal.TryParse(Console.ReadLine(), out decimal sal);

                        var newEmp = new Employee { EmployeeId = id, Name = name, Email = email, Salary = sal };
                        if (empService.AddEmp(newEmp)) Console.WriteLine("Employee added successfully!");
                        else Console.WriteLine("Error: ID already exists or invalid data.");
                        break;

                    case 2:
                        Console.Write("Enter Employee ID to update: ");
                        string upId = Console.ReadLine();
                        Console.Write("New Email: ");
                        string upEmail = Console.ReadLine();
                        Console.Write("New Salary: ");
                        decimal.TryParse(Console.ReadLine(), out decimal upSal);

                        if (empService.UpdateEmployee(upId, upEmail, upSal)) Console.WriteLine("Updated successfully!");
                        else Console.WriteLine("Employee not found.");
                        break;

                    case 3:
                        Console.Write("Enter ID to deactivate: ");
                        string deId = Console.ReadLine();
                        if (empService.Deactivate(deId)) Console.WriteLine("Employee deactivated.");
                        else Console.WriteLine("Employee not found.");
                        break;

                    case 4: 
                        Console.Write("Enter name or ID keyword: ");
                        string keyword = Console.ReadLine();
                        var results = empService.Search(keyword);
                        DisplayEmployees(results);
                        break;

                    case 5:
                        Console.WriteLine("Departments: 0:IT, 1:HR, 2:Sales, 3:Finance...");
                        if (Enum.TryParse(Console.ReadLine(), out Department dept))
                        {
                            DisplayEmployees(empService.FilterByDepartment(dept));
                        }
                        break;

                    case 7:
                        reportService.ShowSalaryReports(empService.GetAll());
                        break;

                    case 8:
                        DisplayEmployees(empService.GetAll());
                        break;

                    case 9:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public static void DisplayEmployees(List<Employee> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
            Console.WriteLine($"\n{"ID",-10} | {"Name",-20} | {"Salary",-10} | {"Status",-10}");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var e in list)
                Console.WriteLine($"{e.EmployeeId,-10} | {e.Name,-20} | {e.Salary,-10:C} | {(e.IsActive ? "Active" : "Inactive")}");
        }

    }
}
