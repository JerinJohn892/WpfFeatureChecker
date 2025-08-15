using System.Collections.Generic;
using WpfCheckerView.Models;

namespace WpfCheckerView.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
    }
}
