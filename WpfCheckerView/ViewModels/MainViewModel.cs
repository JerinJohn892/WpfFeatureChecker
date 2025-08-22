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

        [ObservableProperty]
        private string newEmployeeSalary = string.Empty;

        [ObservableProperty]
        private string newEmployeeIdProof = string.Empty;

        [ObservableProperty]
        private string newEmployeePanNo = string.Empty;

        [ObservableProperty]
        private PaymentBalanceViewModel paymentBalance = new();

        public MainViewModel(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            PaymentBalance.TotalAmount = 100m;
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
                string.IsNullOrWhiteSpace(NewEmployeeDepartment) ||
                string.IsNullOrWhiteSpace(NewEmployeeSalary) ||
                string.IsNullOrWhiteSpace(NewEmployeeIdProof) ||
                string.IsNullOrWhiteSpace(NewEmployeePanNo))
            {
                return;
            }

            if (!int.TryParse(NewEmployeeId, out var id) ||
                !decimal.TryParse(NewEmployeeSalary, out var salary))
            {
                return;
            }

            var employee = new Employee
            {
                Id = id,
                Name = NewEmployeeName,
                Department = NewEmployeeDepartment,
                Salary = salary,
                IdProof = NewEmployeeIdProof,
                PanNo = NewEmployeePanNo
            };

            AddEmployee(employee);

            NewEmployeeId = string.Empty;
            NewEmployeeName = string.Empty;
            NewEmployeeDepartment = string.Empty;
            NewEmployeeSalary = string.Empty;
            NewEmployeeIdProof = string.Empty;
            NewEmployeePanNo = string.Empty;
        }
    }
}
