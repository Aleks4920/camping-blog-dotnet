using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace campingBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<campingBlog.Models.Category> Category { get; set; }
        public DbSet<campingBlog.Models.Post> Post { get; set; }
        //public DbSet<campingBlog.Models.Category> Category { get; set; }
        //public DbSet<campingBlog.Models.Post> Post { get; set; }
    }
}