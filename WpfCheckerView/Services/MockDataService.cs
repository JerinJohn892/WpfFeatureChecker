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
                new Department { Id = 1, Level = 1, Name = "Administration", Package = "A" },
                new Department { Id = 2, Level = 2, Name = "IT", Package = "B" },
                new Department { Id = 3, Level = 2, Name = "Finance", Package = "C" },
                new Department { Id = 4, Level = 1, Name = "HR", Package = "A" },
                new Department { Id = 5, Level = 3, Name = "Sales", Package = "B" }
            };

            _employees = new ObservableCollection<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000, IdProof = "ID123", PanNo = "PAN123" },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000, IdProof = "ID456", PanNo = "PAN456" },
                new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 55000, IdProof = "ID789", PanNo = "PAN789" }
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
