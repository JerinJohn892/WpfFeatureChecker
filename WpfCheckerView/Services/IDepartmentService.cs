using System.Collections.ObjectModel;
using WpfCheckerView.Models;

namespace WpfCheckerView.Services
{
    public interface IDepartmentService
    {
        ObservableCollection<Department> GetDepartments();
    }
}
