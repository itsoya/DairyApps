using System.ComponentModel.DataAnnotations;

namespace DairyApp.Models
{
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;
        [Required(ErrorMessage = "Content is required.")]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
