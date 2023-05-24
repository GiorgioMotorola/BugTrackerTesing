using System.ComponentModel.DataAnnotations;

namespace DemoBug.Enums
{
    public enum Severity
    {
        [Display(Name = "Low")]
        Low,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "High")]
        High
    }
}
