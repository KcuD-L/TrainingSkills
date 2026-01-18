namespace BeaverStream.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Password { get; set; }

        public bool isAdmin { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool isAnon { get; set; }

        public List<Message>? Messages { get; set; }

        public List<Post>? Posts { get; set; }
    }
}
