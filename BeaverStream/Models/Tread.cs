namespace BeaverStream.Models
{
    public class Tread
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Post>? Posts { get; set; }
    }
}
