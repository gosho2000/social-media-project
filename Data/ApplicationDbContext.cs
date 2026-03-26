using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using CourseSocialMedia.Models;

namespace CourseSocialMedia.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

		public DbSet<Post> Posts { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<PostLike> PostLikes { get; set; }

		public DbSet<CommentLike> CommentLikes { get; set; }

public DbSet<CourseSocialMedia.Models.ApplicationRole> ApplicationRole { get; set; } = default!;
}
