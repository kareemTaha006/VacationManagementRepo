using System.ComponentModel.DataAnnotations;

namespace VacationManagement.Models
{
    public class VacationType:EntityBase
    {
        [StringLength(200)]
        [Display(Name="vacation Name")]
        public string  VactionName{ get; set; }=string.Empty;
        [Display(Name = "vacation Color")]
        [StringLength(7)]
        public string BackgroundColor { get; set; } = string.Empty;
        [Display(Name = "Number Days")]
        public int NumberDays{ get; set; }
    }
}
