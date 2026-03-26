


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages;

public class LikePost: PageModel
{
	private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

	private readonly UserManager<ApplicationUser> _userManager;

	private readonly RoleManager<ApplicationRole> _roleMaanger;

	// [BindProperty(SupportsGet = true)]
	// public int Id { get; set; }

	public LikePost(UserManager<ApplicationUser> userManager,
			RoleManager<ApplicationRole> roleManager,
			CourseSocialMedia.Data.ApplicationDbContext context)
	{
		_context = context;
		_userManager = userManager;
		_roleMaanger = roleManager;
	}

	public async Task<IActionResult> OnGetAsync(int? id)
	{
		// Console.WriteLine(id);

		Post? post = _context.Posts.Include(p => p.UserLikes).FirstOrDefault(p => p.Id == id);

		if (post == null)
		{
			return StatusCode(404);
		}

		ApplicationUser? user = await _userManager.GetUserAsync(User);

		if (user == null)
		{
			return RedirectToPage("/Account/Login", new { area = "Identity" });
		}

		if (post.UserLikes?.FirstOrDefault(u => u.User == user) == null)
		{
			PostLike postLike = new PostLike()
			{
				User = user,
				Post = post
			};

			_context.Add(postLike);

			post.UserLikes.Add(postLike);

			user.LikedPosts.Add(postLike);

			_context.Update(post);

			_context.Update(user);

			await _context.SaveChangesAsync();

			return RedirectToPage("Index");
		}
		else
		{
			PostLike postLike = post.UserLikes?.FirstOrDefault(u => u.User == user);

			_context.Remove(postLike);

			await _context.SaveChangesAsync();

			return RedirectToPage("Index");
		}

		return RedirectToPage("Index");
	}
}
