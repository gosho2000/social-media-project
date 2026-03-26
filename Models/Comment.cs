


namespace CourseSocialMedia.Models;

public class Comment
{
	public int Id { get; set; }

	public string Body { get; set; }

	public string UserId { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.Now;

	public ApplicationUser? User { get; set; } = null!;

	public ICollection<CommentLike>? UserLikes { get; set; }

	public int PostId { get; set; }

	public Post? Post { get; set; }
}
