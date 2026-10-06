using System.ComponentModel.DataAnnotations;

namespace campingBlog.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

        public List<Post>? Posts { get; set; }
    }
}
