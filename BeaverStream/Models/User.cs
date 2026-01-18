namespace BeaverStream.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PasswordHash { get; set; }
        public bool isAdmin { get; set; } = false;
        public bool ReadOnly { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Message>? Messages { get; set; }
        public List<int>? BannedInTreads { get; set; }
        public bool isBannedAll { get; set; } = false;
    }
}
