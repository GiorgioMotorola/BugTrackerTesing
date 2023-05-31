using DemoBug.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBug.Models
{
    public class Bug
    {
        public int BugId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Count { get; set; } = 1;

        [DataType(DataType.Date)]
        public DateTime? DateOpened { get; set; }
        public Status? status { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateResolved { get; set; }
        public Severity? severity { get; set; }
        public int? AssignedUserId { get; set; }
        public virtual User? AssignedUser { get; set; }
    }
}
