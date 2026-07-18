using EmployeeManagementConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementConsoleApp.Services
{
    internal class EmployeeService
    {

        private List<Employee> _employees { get; set; } = new List<Employee>();
        public EmployeeService()
        {
            SeedData();
        }

        private void SeedData()
        {
            _employees.Add(new Employee { EmployeeId = "EMP-001", Name = "Mohamed Ayman", Email = "mohamed@test.com", Department = Department.IT, Position = "Backend Developer", Salary = 20000, HireDate = new DateTime(2025, 1, 10) });
            _employees.Add(new Employee { EmployeeId = "EMP-002", Name = "Sara Adel", Email = "sara@test.com", Department = Department.HR, Position = "HR Specialist", Salary = 12000, HireDate = new DateTime(2024, 5, 15) });
            _employees.Add(new Employee { EmployeeId = "EMP-003", Name = "Ahmed Tarek", Email = "ahmed@test.com", Department = Department.IT, Position = "Junior Developer", Salary = 9000, HireDate = new DateTime(2026, 1, 1) });
            _employees.Add(new Employee { EmployeeId = "EMP-004", Name = "Omar Samir", Email = "omar@test.com", Department = Department.Sales, Position = "Sales Executive", Salary = 11000, HireDate = new DateTime(2023, 11, 20) });
            _employees.Add(new Employee { EmployeeId = "EMP-005", Name = "Mariam Hassan", Email = "mariam@test.com", Department = Department.Finance, Position = "Accountant", Salary = 14000, HireDate = new DateTime(2022, 09, 11) });
            _employees.Add(new Employee { EmployeeId = "EMP-006", Name = "Khaled Ali", Email = "khaled@test.com", Department = Department.IT, Position = "DevOps Trainee", Salary = 10000, HireDate = new DateTime(2026, 02, 01) });
            _employees.Add(new Employee { EmployeeId = "EMP-007", Name = "Nour Emad", Email = "nour@test.com", Department = Department.Marketing, Position = "Content Specialist", Salary = 9500, HireDate = new DateTime(2025, 07, 08) });
            _employees.Add(new Employee { EmployeeId = "EMP-008", Name = "Youssef Nabil", Email = "youssef@test.com", Department = Department.Sales, Position = "Sales Manager", Salary = 18000, HireDate = new DateTime(2021, 03, 17), IsActive = false });
            _employees.Add(new Employee { EmployeeId = "EMP-009", Name = "Dina Farouk", Email = "dina@test.com", Department = Department.HR, Position = "Recruiter", Salary = 10500, HireDate = new DateTime(2024, 02, 13) });
            _employees.Add(new Employee { EmployeeId = "EMP-010", Name = "Hady Mahmoud", Email = "hady@test.com", Department = Department.IT, Position = "QA Engineer", Salary = 13000, HireDate = new DateTime(2025, 10, 01) });
            _employees.Add(new Employee { EmployeeId = "EMP-011", Name = "Salma Taha", Email = "salma@test.com", Department = Department.Finance, Position = "Finance Manager", Salary = 26000, HireDate = new DateTime(2020, 12, 12) });
            _employees.Add(new Employee { EmployeeId = "EMP-012", Name = "Ali Mostafa", Email = "ali@test.com", Department = Department.Support, Position = "Support Agent", Salary = 8000, HireDate = new DateTime(2026, 03, 05) });
        }


        public List<Employee> GetAll()
        {
            return _employees;
        }


        public Employee findById(string id)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == id);
            return emp;
        }

        public List<Employee> SearchByDep(Department department)
        {
            var emp = _employees.Where(d => d.Department == department)
                .Where(a => a.IsActive == true).ToList();
            return emp;
        }

        public List<Employee> Search(string keyword) =>
             _employees.Where(e => e.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                  e.EmployeeId.Equals(keyword, StringComparison.OrdinalIgnoreCase)).ToList();


        public List<Employee> FilterByDepartment(Department dept) =>
            _employees.Where(e => e.Department == dept).ToList();


        public bool Deactivate(string id)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null) return false;
            emp.IsActive = false;
            return true;
        }

        public bool AddEmp(Employee emp)
        {
            if (emp != null)
            {
                if (_employees.Any(e => e.EmployeeId == emp.EmployeeId)) return false;
                _employees.Add(emp);
                return true;
            }
            return false;
        }


        public bool UpdateEmployee(string id, string email, decimal salary)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null || salary <= 0) return false;
            emp.Email = email;
            emp.Salary = salary;
            return true;
        }

    }
}
