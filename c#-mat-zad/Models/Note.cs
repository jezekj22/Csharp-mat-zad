using System.ComponentModel.DataAnnotations;

namespace c__mat_zad.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Content { get; set; } = "";

        public bool Important { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
    }
}
