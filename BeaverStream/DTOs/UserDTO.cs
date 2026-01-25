using BeaverStream.Models;
using System.ComponentModel.DataAnnotations;

namespace BeaverStream.DTOs
{
    public class UserCreateDto
    {
        [StringLength(50, MinimumLength = 3)] public required string Name { get; set; }
        public required string Password { get; set; }
    }

    public class UserLoginDto
    {
        public required string Name { get; set; }
        [MinLength(6)] public required string Password { get; set; }
    }

    public class UserInfoDto
    {
        [StringLength(50)] public string? Name { get; set; }
        public bool ReadOnly { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<MessagePreviewDto>? Messages { get; set; }
    }

    public class UserInfoAdminDto : UserInfoDto
    {
        public bool IsBannedAll { get; set; }
        public List<int>? BannedInThreads { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime? LastLoginAt { get; set; }
        public string? LastIpHash { get; set; }
        public int TotalMessagesCount { get; set; }
    }
    public class PagedResponse<T>
    {
        public List<T> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
