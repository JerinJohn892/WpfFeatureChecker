using System.Collections.Generic;
using WpfCheckerView.Models;

namespace WpfCheckerView.Services
{
    /// <summary>
    /// Provides in-memory sample data for design-time or development use.
    /// </summary>
    public class MockDataService : IEmployeeService, IDepartmentService
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return new[]
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR" },
                new Employee { Id = 2, Name = "Bob", Department = "IT" },
                new Employee { Id = 3, Name = "Charlie", Department = "Finance" }
            };
        }

        public IEnumerable<Department> GetDepartments()
        {
            return new[]
            {
                new Department { Id = 1, Level = 1, Name = "Administration", Package = "A" },
                new Department { Id = 2, Level = 2, Name = "IT", Package = "B" },
                new Department { Id = 3, Level = 2, Name = "Finance", Package = "C" },
                new Department { Id = 4, Level = 1, Name = "HR", Package = "A" },
                new Department { Id = 5, Level = 3, Name = "Sales", Package = "B" }
            };
        }
    }
}
