


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Identity;

using CourseSocialMedia.Models;

namespace CourseSocialMedia.Pages;

public class DeletePost: PageModel
{
	private readonly CourseSocialMedia.Data.ApplicationDbContext _context;

	private readonly UserManager<ApplicationUser> _userManager;

	private readonly RoleManager<ApplicationRole> _roleMaanger;

	// [BindProperty(SupportsGet = true)]
	// public int Id { get; set; }

	public DeletePost(UserManager<ApplicationUser> userManager,
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

		Post? post = _context.Posts.FirstOrDefault(p => p.Id == id);

		if (post == null)
		{
			return StatusCode(404);
		}

		ApplicationUser? user = await _userManager.GetUserAsync(User);

		if (user == null)
		{
			return StatusCode(403);
		}

		if (post.Uploader == user || await _userManager.IsInRoleAsync(user, "Admin"))
		{
			_context.Remove(post);

			await _context.SaveChangesAsync();

			return RedirectToPage("Index");
		}

		return StatusCode(500);
	}
}
