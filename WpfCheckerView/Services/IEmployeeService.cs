using System.Collections.ObjectModel;
using WpfCheckerView.Models;

namespace WpfCheckerView.Services
{
    public interface IEmployeeService
    {
        ObservableCollection<Employee> GetEmployees();

        void AddEmployee(Employee employee);
    }
}
