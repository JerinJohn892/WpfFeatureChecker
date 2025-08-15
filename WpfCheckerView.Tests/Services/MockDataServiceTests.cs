using System.Linq;
using WpfCheckerView.Models;
using WpfCheckerView.Services;
using Xunit;

namespace WpfCheckerView.Tests.Services;

public class MockDataServiceTests
{
    [Fact]
    public void GetEmployees_ShouldReturnSeededEmployees()
    {
        var service = new MockDataService();

        var employees = service.GetEmployees();

        Assert.NotNull(employees);
        Assert.Equal(3, employees.Count);
    }

    [Fact]
    public void AddEmployee_ShouldIncreaseEmployeeCount()
    {
        var service = new MockDataService();
        var newEmployee = new Employee
        {
            Id = 4,
            Name = "David",
            Department = "IT",
            Salary = 65000,
            IdProof = "ID000",
            PanNo = "PAN000"
        };

        service.AddEmployee(newEmployee);

        Assert.Equal(4, service.GetEmployees().Count);
        Assert.Contains(service.GetEmployees(), e => e.Id == 4 && e.Name == "David");
    }

    [Fact]
    public void GetDepartments_ShouldReturnSeededDepartments()
    {
        var service = new MockDataService();

        var departments = service.GetDepartments();

        Assert.NotNull(departments);
        Assert.Equal(5, departments.Count);
    }
}
