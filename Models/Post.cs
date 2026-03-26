


namespace CourseSocialMedia.Models;

public class Post
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }

	public string UploaderId { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.Now;

	public ApplicationUser? Uploader { get; set; }

	public ICollection<Image>? Images { get; set; }

	public ICollection<PostLike>? UserLikes { get; set; }

	public ICollection<Comment>? Comments { get; set; }
}
