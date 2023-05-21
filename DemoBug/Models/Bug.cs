namespace DemoBug.Models
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        
        public int? AssignedUserId { get; set; } // Nullable int to represent unassigned bugs

        public virtual User? AssignedUser { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
