using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        [ObservableProperty]
        private string newEmployeeId = string.Empty;

        [ObservableProperty]
        private string newEmployeeName = string.Empty;

        [ObservableProperty]
        private string newEmployeeDepartment = string.Empty;

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

        [RelayCommand]
        private void AddNewEmployee()
        {
            if (string.IsNullOrWhiteSpace(NewEmployeeId) ||
                string.IsNullOrWhiteSpace(NewEmployeeName) ||
                string.IsNullOrWhiteSpace(NewEmployeeDepartment))
            {
                return;
            }

            if (!int.TryParse(NewEmployeeId, out var id))
            {
                return;
            }

            var employee = new Employee
            {
                Id = id,
                Name = NewEmployeeName,
                Department = NewEmployeeDepartment
            };

            AddEmployee(employee);

            NewEmployeeId = string.Empty;
            NewEmployeeName = string.Empty;
            NewEmployeeDepartment = string.Empty;
        }
    }
}
