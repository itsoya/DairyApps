using System.ComponentModel.DataAnnotations;

namespace DairyApp.Models
{
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required DateTime Created { get; set; } = DateTime.Now;

    }
}
