using VacationManagement.Models;

namespace VacationManagement.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee DomainModel { get; set; }
        public List<Employee> DomainList { get; set; }=new List<Employee>();
        public List<Department> Departments { get; set; } = new();
    }
}
