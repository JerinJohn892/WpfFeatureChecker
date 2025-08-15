using System.Collections.Generic;
using WpfCheckerView.Models;

namespace WpfCheckerView.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
    }
}
