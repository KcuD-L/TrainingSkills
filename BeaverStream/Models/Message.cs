using System.ComponentModel.DataAnnotations;

namespace BeaverStream.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [StringLength(500)]
        public required string Text { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
        [StringLength(200)]
        public string? ImageUrl { get; set; }
        public string? PosterIp { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

    }
}
