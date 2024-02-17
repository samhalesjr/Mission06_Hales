using System.ComponentModel.DataAnnotations;

namespace Mission06_Hales.Models
{
    public class MovieCollection
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; } = false;

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
