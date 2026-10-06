using System.ComponentModel.DataAnnotations;

namespace campingBlog.Models
{
    public class Post
    {

        [Required]
        public int PostId { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Content { get; set; }

        [Required]
        [MaxLength(60)]
        public string? Author { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Category? Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
