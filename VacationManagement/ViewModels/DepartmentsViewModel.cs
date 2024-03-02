using VacationManagement.Models;

namespace VacationManagement.ViewModels
{
    public class DepartmentsViewModel
    {
        public Department DomainModel { get; set; }
        public List<Department> DomainList { get; set; }=new List<Department>();
    }
}
