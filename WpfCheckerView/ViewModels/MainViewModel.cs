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
        private ObservableCollection<Employee> employees = new();

        [ObservableProperty]
        private ObservableCollection<Department> departments = new();

        public MainViewModel(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            LoadData();
        }

        private void LoadData()
        {
            Employees = new ObservableCollection<Employee>(_employeeService.GetEmployees());
            Departments = new ObservableCollection<Department>(_departmentService.GetDepartments());
        }
    }
}
