using System.Collections.ObjectModel;
using WpfCheckerView.Models;

namespace WpfCheckerView.Services
{
    /// <summary>
    /// Provides in-memory sample data for design-time or development use.
    /// </summary>
    public class MockDataService : IEmployeeService, IDepartmentService
    {
        private readonly ObservableCollection<Employee> _employees;
        private readonly ObservableCollection<Department> _departments;

        public MockDataService()
        {
            _departments = new ObservableCollection<Department>
            {
                new Department { Id = 1,  Level = 1, Name = "Administration", Package = "A" },
                new Department { Id = 2,  Level = 2, Name = "IT", Package = "B" },
                new Department { Id = 3,  Level = 2, Name = "Finance", Package = "C" },
                new Department { Id = 4,  Level = 1, Name = "HR", Package = "A" },
                new Department { Id = 5,  Level = 3, Name = "Sales", Package = "B" },
                new Department { Id = 6,  Level = 2, Name = "Service", Package = "B" },
                new Department { Id = 7,  Level = 2, Name = "Support", Package = "C" },
                new Department { Id = 8,  Level = 3, Name = "Strategy", Package = "A" },
                new Department { Id = 9,  Level = 1, Name = "Supply Chain", Package = "B" },
                new Department { Id = 10, Level = 2, Name = "Security", Package = "C" },
                new Department { Id = 11, Level = 3, Name = "Sales Operations", Package = "A" },
                new Department { Id = 12, Level = 1, Name = "Social Media", Package = "B" },
                new Department { Id = 13, Level = 2, Name = "Software Engineering", Package = "C" },
                new Department { Id = 14, Level = 3, Name = "Student Relations", Package = "A" },
                new Department { Id = 15, Level = 2, Name = "Sponsorship", Package = "B" }
            };

            _employees = new ObservableCollection<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000, IdProof = "ID123", PanNo = "PAN123", Status = true },
                new Employee { Id = 1, Name = "Alice", Department = "IT", Salary = 50000, IdProof = "ID123", PanNo = "PAN123", Status = true },
                new Employee { Id = 3, Name = "Joy", Department = "Support", Salary = 40000, IdProof = "ID789", PanNo = "PAN123", Status = true },
                new Employee { Id = 4, Name = "Sibu", Department = "Support", Salary = 6000, IdProof = "ID124", PanNo = "PAN456", Status = true },
                new Employee { Id = 4, Name = "Sibu", Department = "Service", Salary = 6000, IdProof = "ID124", PanNo = "PAN456", Status = true },
                new Employee { Id = 6, Name = "Charlie", Department = "Finance", Salary = 6000, IdProof = "ID799", PanNo = "PAN789", Status = true }
            };
        }

        public ObservableCollection<Employee> GetEmployees() => _employees;

        public ObservableCollection<Department> GetDepartments() => _departments;

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
    }
}
