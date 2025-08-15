using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCheckerView
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Package { get; set; }
    }
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Employee> employees;

        [ObservableProperty]
        private ObservableCollection<Department> departments;
        public MainViewModel()
        {
            Departments = new ObservableCollection<Department>
            {
                new Department { Id = 1, Level = 1, Name = "Administration", Package = "A" },
                new Department { Id = 2, Level = 2, Name = "IT", Package = "B" },
                new Department { Id = 3, Level = 2, Name = "Finance", Package = "C" },
                new Department { Id = 4, Level = 1, Name = "HR", Package = "A" },
                new Department { Id = 5, Level = 3, Name = "Sales", Package = "B" }
            };

            Employees = new ObservableCollection<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR" },
            new Employee { Id = 2, Name = "Bob", Department = "IT" },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance" }
        };
        }
    }
}
