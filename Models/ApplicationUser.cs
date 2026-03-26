


using Microsoft.AspNetCore.Identity;

namespace CourseSocialMedia.Models;

public class ApplicationUser : IdentityUser
{
	public string? DisplayName { get; set; }

	// public string? RoleId { get; set; }
	//
	// public IdentityRole? Role { get; set; }
	
	public bool IsBanned { get; set; } = false;

	public ICollection<Post>? Posts { get; set; }

	public ICollection<PostLike>? LikedPosts { get; set; }

	public ICollection<Comment>? Comments { get; set; }

	public ICollection<CommentLike>? LikedComments { get; set; }


}
