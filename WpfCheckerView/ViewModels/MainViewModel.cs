using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfCheckerView.Models;
using WpfCheckerView.Services;

namespace WpfCheckerView.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        [ObservableProperty]
        private ObservableCollection<Employee> employees = null!;

        [ObservableProperty]
        private ObservableCollection<Department> departments = null!;

        public MainViewModel(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            LoadData();
        }

        private void LoadData()
        {
            Employees = _employeeService.GetEmployees();
            Departments = _departmentService.GetDepartments();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);
        }
    }
}
