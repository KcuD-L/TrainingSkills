using System.ComponentModel.DataAnnotations;

namespace BeaverStream.DTOs
{
    public class MessageCreateBaseDto
    {
        [StringLength(500)] public required string Text { get; set; }
        public string? AuthorName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }

    public class OpMessageCreateDto : MessageCreateBaseDto
    {
        [StringLength(200)] public required string Title { get; set; }
        public bool IsHidden { get; set; }
    }

    public class ReplyMessageCreateDto : MessageCreateBaseDto
    {
        public required int ParentMessageId { get; set; }
    }

    public class MessageBaseDto
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public string? ImageUrl { get; set; }
        public string? AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsOp { get; set; }
        public int? ParentMessageId { get; set; }
    }

    public class OpMessageDto : MessageBaseDto
    {
        public required string Title { get; set; }
        public int ThreadId { get; set; }
        public string? ThreadTitle { get; set; }
    }

    public class MessageDto : MessageBaseDto
    {
        //Для приличия, что бы не писать базовый в использовании
    }

    //ДЛЯ АДМИНИСТРАТОРА
    public class MessageAdminDto : MessageDto
    {
        public string? PosterIpHash { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? LastEdited { get; set; }
        public bool IsHidden { get; set; }
    }
}