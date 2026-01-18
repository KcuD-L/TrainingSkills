namespace BeaverStream.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required string MainText { get; set; }
        public List<Message>? MessageList { get; set; }
        public string? ImagePath { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public string? PosterIp { get; set; }

        public int TreadId { get; set; }
        public Tread Tread { get; set; } = null!;
    }
}
