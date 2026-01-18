using BeaverStream.Models;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace BeaverStream.DTOs
{
    #region For user

    public class ThreadCreateDto
    {
        [StringLength(200)]
        public required string Title { get; set; }
        public bool isHidden { get; set; }
    }

    public class ThreadPreviewDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
    }

    public class ThreadPageDto : ThreadPreviewDto
    {
        public DateTime CreatedAt { get; set; }
        public List<OpMessageDto>? Message { get; set; }
    }

    #endregion

    #region For Admin
    public class ThreadAdminPreviewDTO : ThreadPreviewDto
    {
        public bool isHidden { get; set; }
    }

    public class ThreadAdminPageDto : ThreadPageDto
    {
        public bool isHidden { get; set; }
    }
    #endregion
}