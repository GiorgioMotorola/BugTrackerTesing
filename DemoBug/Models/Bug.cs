using DemoBug.Enums;

namespace DemoBug.Models
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; } = 1;
        public Severity severity { get; set; }
        public int? AssignedUserId { get; set; }
        public virtual User? AssignedUser { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
