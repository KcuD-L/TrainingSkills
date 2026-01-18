using System.ComponentModel.DataAnnotations;

namespace BeaverStream.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [StringLength(500)]
        public required string MainText { get; set; }
        public List<Message>? MessageList { get; set; }
        [StringLength(200)]
        public string? ImageUrl { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public string? PosterIp { get; set; }

        public int ThreadId { get; set; }
        public Thread Thread { get; set; } = null!;
    }
}
