using VacationManagement.Models;

namespace VacationManagement.ViewModels
{
    public class VacationTypeViewModel
    {
        public VacationType DomainModel { get; set; }
        public List<VacationType> DomainList { get; set; }=new List<VacationType>();
    }
}
