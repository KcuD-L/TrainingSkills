using System.ComponentModel.DataAnnotations;

namespace BeaverStream.Models
{
    public class Message
    {
        //Общая информация обязательная как для ОПа, так и для обсуждения
        public bool IsOp { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [StringLength(500)] public required string Text { get; set; }
        [StringLength(200)] public string? ImageUrl { get; set; }
        public List<Message> Replies { get; set; } = new(); //список ответов

        //важно только ОПу
        #region For OP 
        
        [StringLength(200)] public string? Title { get; set; }
        public int ThreadId { get; set; }
        public Thread Thread { get; set; } = null!;

        #endregion
        //информация важна только для обсуждения
        public Message? ParentMessage { get; set; }

        //нигде не показывается, но важна
        #region metainf

        public int? UserId { get; set; }
        public User? User { get; set; } //исключение, если пользователь зарегистрирован, то будет браться ник, иначе анон
        public string? PosterIpHash { get; set; }

        #endregion
    }
}
