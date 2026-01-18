using System.ComponentModel.DataAnnotations;

namespace BeaverStream.Models
{
    public class Thread
    {
        public int Id { get; set; }
        [StringLength(200)]
        public required string Title { get; set; }
        public bool isHidden { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Message> Messages { get; set; } = new();
        public Message? OpMessage => Messages.FirstOrDefault(m => m.IsOp);
    }
}
